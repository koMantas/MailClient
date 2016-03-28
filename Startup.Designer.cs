namespace MailClient
{
    partial class Startup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IMAPServerAddressLabel = new System.Windows.Forms.Label();
            this.IMAPPortLabel = new System.Windows.Forms.Label();
            this.SSLLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PassLabel = new System.Windows.Forms.Label();
            this.IMAPServerAddress = new System.Windows.Forms.TextBox();
            this.IMAPPort = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.IsSSL = new System.Windows.Forms.CheckBox();
            this.SingUpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IMAPServerAddressLabel
            // 
            this.IMAPServerAddressLabel.AutoSize = true;
            this.IMAPServerAddressLabel.Location = new System.Drawing.Point(23, 20);
            this.IMAPServerAddressLabel.Name = "IMAPServerAddressLabel";
            this.IMAPServerAddressLabel.Size = new System.Drawing.Size(105, 13);
            this.IMAPServerAddressLabel.TabIndex = 1;
            this.IMAPServerAddressLabel.Text = "IMAP server address";
            // 
            // IMAPPortLabel
            // 
            this.IMAPPortLabel.AutoSize = true;
            this.IMAPPortLabel.Location = new System.Drawing.Point(290, 20);
            this.IMAPPortLabel.Name = "IMAPPortLabel";
            this.IMAPPortLabel.Size = new System.Drawing.Size(54, 13);
            this.IMAPPortLabel.TabIndex = 2;
            this.IMAPPortLabel.Text = "IMAP port";
            // 
            // SSLLabel
            // 
            this.SSLLabel.AutoSize = true;
            this.SSLLabel.Location = new System.Drawing.Point(364, 20);
            this.SSLLabel.Name = "SSLLabel";
            this.SSLLabel.Size = new System.Drawing.Size(27, 13);
            this.SSLLabel.TabIndex = 3;
            this.SSLLabel.Text = "SSL";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(23, 63);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 4;
            this.UsernameLabel.Text = "Username";
            // 
            // PassLabel
            // 
            this.PassLabel.AutoSize = true;
            this.PassLabel.Location = new System.Drawing.Point(23, 105);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(53, 13);
            this.PassLabel.TabIndex = 5;
            this.PassLabel.Text = "Password";
            // 
            // IMAPServerAddress
            // 
            this.IMAPServerAddress.Location = new System.Drawing.Point(26, 36);
            this.IMAPServerAddress.Name = "IMAPServerAddress";
            this.IMAPServerAddress.Size = new System.Drawing.Size(255, 20);
            this.IMAPServerAddress.TabIndex = 6;
            // 
            // IMAPPort
            // 
            this.IMAPPort.Location = new System.Drawing.Point(287, 36);
            this.IMAPPort.Name = "IMAPPort";
            this.IMAPPort.Size = new System.Drawing.Size(67, 20);
            this.IMAPPort.TabIndex = 7;
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(26, 79);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(365, 20);
            this.Username.TabIndex = 8;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(26, 123);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(365, 20);
            this.Password.TabIndex = 9;
            // 
            // IsSSL
            // 
            this.IsSSL.AutoSize = true;
            this.IsSSL.Location = new System.Drawing.Point(370, 40);
            this.IsSSL.Name = "IsSSL";
            this.IsSSL.Size = new System.Drawing.Size(15, 14);
            this.IsSSL.TabIndex = 10;
            this.IsSSL.UseVisualStyleBackColor = true;
            // 
            // SingUpButton
            // 
            this.SingUpButton.Location = new System.Drawing.Point(175, 155);
            this.SingUpButton.Name = "SingUpButton";
            this.SingUpButton.Size = new System.Drawing.Size(75, 23);
            this.SingUpButton.TabIndex = 11;
            this.SingUpButton.Text = "Sign up";
            this.SingUpButton.UseVisualStyleBackColor = true;
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 199);
            this.Controls.Add(this.SingUpButton);
            this.Controls.Add(this.IsSSL);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.IMAPPort);
            this.Controls.Add(this.IMAPServerAddress);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.SSLLabel);
            this.Controls.Add(this.IMAPPortLabel);
            this.Controls.Add(this.IMAPServerAddressLabel);
            this.Name = "Startup";
            this.Text = "Startup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IMAPServerAddressLabel;
        private System.Windows.Forms.Label IMAPPortLabel;
        private System.Windows.Forms.Label SSLLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.TextBox IMAPServerAddress;
        private System.Windows.Forms.TextBox IMAPPort;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.CheckBox IsSSL;
        private System.Windows.Forms.Button SingUpButton;
    }
}

