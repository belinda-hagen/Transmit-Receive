using System;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public partial class Form1 : Form
    {
        // Initialize Components
        public Form1()
        {
            InitializeComponent();
        }

        // Handle Open button click
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.ShowDialog();
            boxPath.Text = fileDlg.FileName;
        }

        // Handle Send button click
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(boxPath.Text))
            {
                FileInfo fi = new FileInfo(boxPath.Text);
                byte[] fileNameBytes = Encoding.UTF8.GetBytes(fi.Name);
                byte[] fileNameLen = BitConverter.GetBytes(fileNameBytes.Length);
                Stream streamFile = File.OpenRead(boxPath.Text);
                byte[] buffer = new byte[streamFile.Length];
                streamFile.Read(buffer, 0, buffer.Length);

                TcpClient socket = new TcpClient("Localhost", 1234);
                NetworkStream netStream = socket.GetStream();
                netStream.Write(fileNameLen, 0, fileNameLen.Length);
                netStream.Write(fileNameBytes, 0, fileNameBytes.Length);
                netStream.Write(buffer, 0, buffer.Length);
                netStream.Close();
            }
        }
    }
}