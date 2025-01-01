namespace FTP_Client_Project
{
    partial class FTPManager
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtLocalSite = new System.Windows.Forms.Label();
            this.tvLocal = new System.Windows.Forms.TreeView();
            this.lvLocal = new System.Windows.Forms.ListView();
            this.lvRemote = new System.Windows.Forms.ListView();
            this.tvRemote = new System.Windows.Forms.TreeView();
            this.txtRemoteSite = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "UserName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(58, 44);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 21);
            this.txtIP.TabIndex = 4;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(242, 44);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 21);
            this.txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(429, 44);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 21);
            this.txtPassword.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnConnect.Location = new System.Drawing.Point(585, 44);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(90, 27);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDisconnect.Location = new System.Drawing.Point(585, 77);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(90, 27);
            this.btnDisconnect.TabIndex = 8;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            // 
            // txtLocalSite
            // 
            this.txtLocalSite.AutoSize = true;
            this.txtLocalSite.Location = new System.Drawing.Point(36, 126);
            this.txtLocalSite.Name = "txtLocalSite";
            this.txtLocalSite.Size = new System.Drawing.Size(61, 12);
            this.txtLocalSite.TabIndex = 9;
            this.txtLocalSite.Text = "Local Site";
            // 
            // tvLocal
            // 
            this.tvLocal.Location = new System.Drawing.Point(38, 141);
            this.tvLocal.Name = "tvLocal";
            this.tvLocal.Size = new System.Drawing.Size(304, 107);
            this.tvLocal.TabIndex = 10;
            // 
            // lvLocal
            // 
            this.lvLocal.HideSelection = false;
            this.lvLocal.Location = new System.Drawing.Point(38, 254);
            this.lvLocal.Name = "lvLocal";
            this.lvLocal.Size = new System.Drawing.Size(304, 107);
            this.lvLocal.TabIndex = 11;
            this.lvLocal.UseCompatibleStateImageBehavior = false;
            // 
            // lvRemote
            // 
            this.lvRemote.HideSelection = false;
            this.lvRemote.Location = new System.Drawing.Point(429, 254);
            this.lvRemote.Name = "lvRemote";
            this.lvRemote.Size = new System.Drawing.Size(304, 107);
            this.lvRemote.TabIndex = 13;
            this.lvRemote.UseCompatibleStateImageBehavior = false;
            // 
            // tvRemote
            // 
            this.tvRemote.Location = new System.Drawing.Point(429, 141);
            this.tvRemote.Name = "tvRemote";
            this.tvRemote.Size = new System.Drawing.Size(304, 107);
            this.tvRemote.TabIndex = 12;
            // 
            // txtRemoteSite
            // 
            this.txtRemoteSite.AutoSize = true;
            this.txtRemoteSite.Location = new System.Drawing.Point(427, 126);
            this.txtRemoteSite.Name = "txtRemoteSite";
            this.txtRemoteSite.Size = new System.Drawing.Size(73, 12);
            this.txtRemoteSite.TabIndex = 14;
            this.txtRemoteSite.Text = "Remote Site";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(363, 225);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(33, 23);
            this.btnUpload.TabIndex = 15;
            this.btnUpload.Text = ">>";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(363, 254);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(33, 23);
            this.btnDownload.TabIndex = 16;
            this.btnDownload.Text = "<<";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(38, 407);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(695, 66);
            this.txtStatus.TabIndex = 17;
            // 
            // txtProgress
            // 
            this.txtProgress.AutoSize = true;
            this.txtProgress.Location = new System.Drawing.Point(36, 392);
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(91, 12);
            this.txtProgress.TabIndex = 18;
            this.txtProgress.Text = "Progress Detail";
            // 
            // FTPManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.txtRemoteSite);
            this.Controls.Add(this.lvRemote);
            this.Controls.Add(this.tvRemote);
            this.Controls.Add(this.lvLocal);
            this.Controls.Add(this.tvLocal);
            this.Controls.Add(this.txtLocalSite);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FTPManager";
            this.Text = "FTPManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label txtLocalSite;
        private System.Windows.Forms.TreeView tvLocal;
        private System.Windows.Forms.ListView lvLocal;
        private System.Windows.Forms.ListView lvRemote;
        private System.Windows.Forms.TreeView tvRemote;
        private System.Windows.Forms.Label txtRemoteSite;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label txtProgress;
    }
}

