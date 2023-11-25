namespace Receive
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.ipLabel = new System.Windows.Forms.Label();
            this.infoList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ipLabel
            // 
            this.ipLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ipLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLabel.Location = new System.Drawing.Point(12, 14);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(348, 22);
            this.ipLabel.TabIndex = 0;
            this.ipLabel.Text = "Your IP-Address: ---.---.-.---";
            this.ipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoList
            // 
            this.infoList.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoList.FormattingEnabled = true;
            this.infoList.ItemHeight = 17;
            this.infoList.Location = new System.Drawing.Point(12, 49);
            this.infoList.Name = "infoList";
            this.infoList.Size = new System.Drawing.Size(347, 293);
            this.infoList.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 353);
            this.Controls.Add(this.infoList);
            this.Controls.Add(this.ipLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(388, 392);
            this.MinimumSize = new System.Drawing.Size(388, 392);
            this.Name = "Form1";
            this.Text = "Receive";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.ListBox infoList;
    }
}

