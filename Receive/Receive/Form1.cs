using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Receive
{
    public partial class Form1 : Form
    {
        private List<TcpClient> _clientSockets = new List<TcpClient>();
        private readonly int _bufferSize = 1024;
        private readonly string _targetFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "readme.txt");
        private const int Port = 1234;

        // Initializes Components
        public Form1()
        {
            InitializeComponent();
        }

        // Load IP and start listener thread
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayLocalIPAddress();
            StartListenerThread();
        }

        // Display local IP address
        private void DisplayLocalIPAddress()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            ipLabel.Text = $"Your IP-Address: {ipHostInfo.AddressList[0]}";
        }

        // Start TCP listener thread
        private void StartListenerThread()
        {
            Thread listenerThread = new Thread(ListenForClients)
            {
                IsBackground = true
            };
            listenerThread.Start();
        }

        // Listen for and handle client connections
        private void ListenForClients()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, Port);
            listener.Start();

            try
            {
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    if (client.Connected)
                    {
                        UpdateConnectionStatus(client);
                        _clientSockets.Add(client);

                        Thread clientThread = new Thread(HandleClientCommunication)
                        {
                            IsBackground = true
                        };
                        clientThread.Start();
                    }
                }
            }
            finally
            {
                listener.Stop();
            }
        }

        // Handle client data transfer
        private void HandleClientCommunication()
        {
            TcpClient clientSocket;
            lock (_clientSockets)
            {
                clientSocket = _clientSockets[_clientSockets.Count - 1];
            }

            using (NetworkStream networkStream = clientSocket.GetStream())
            {
                byte[] fileNameLenBytes = new byte[4];
                networkStream.Read(fileNameLenBytes, 0, 4);
                int fileNameLen = BitConverter.ToInt32(fileNameLenBytes, 0);

                byte[] fileNameBytes = new byte[fileNameLen];
                networkStream.Read(fileNameBytes, 0, fileNameLen);
                string fileName = Encoding.UTF8.GetString(fileNameBytes);

                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                using (FileStream fileStream = File.OpenWrite(filePath))
                {
                    byte[] buffer = new byte[_bufferSize];
                    int bytesRead;
                    while ((bytesRead = networkStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }
                }
            }

            UpdateTransferStatus("Transfer Complete");
            clientSocket.Close();
        }


        // Update UI with connection status
        private void UpdateConnectionStatus(TcpClient client)
        {
            if (infoList.InvokeRequired)
            {
                infoList.Invoke((MethodInvoker)delegate
                {
                    infoList.Items.Add($"{client.Client.RemoteEndPoint} Connected");
                });
            }
        }

        // Update UI with transfer status
        private void UpdateTransferStatus(string statusMessage)
        {
            if (infoList.InvokeRequired)
            {
                infoList.Invoke((MethodInvoker)delegate
                {
                    infoList.Items.Add(statusMessage);
                });
            }
        }
    }
}