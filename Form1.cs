using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace FTP_Client_Project
{
    public partial class FTPManager : Form
    {
        public FTPManager()
        {
            InitializeComponent();

            //기본 경로 설정
            LoadLocalDirectories("C:\\");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ftpServer = txtIP.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServer);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    txtStatus.Text = "FTP 연결 성공";
                    LoadRemoteDirectories("/");
                }
            }
            catch (Exception ex)
            {
                txtStatus.Text = "FTP 연결 실패: " + ex.Message;
            }

        }

        private void LoadRemoteDirectories(string path)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txtIP.Text + path);
                request.Credentials = new NetworkCredential(txtUsername.Text, txtPassword.Text);
                request.Method= WebRequestMethods.Ftp.ListDirectory;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    tvRemote.Nodes.Clear();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        tvRemote.Nodes.Add(line);
                    }
                }
                txtStatus.Text = "원격 디렉토리 로드 성공";
            }
            catch (Exception ex)
            {
                txtStatus.Text = "원격 디렉토리 로드 실패: " + ex.Message;
            }
        }

        private void LoadLocalDirectories(string path)
        {
            try
            {
                tvLocal.Nodes.Clear();
                string[] directories = Directory.GetDirectories(path);
                foreach (string dir in directories)
                {
                    tvLocal.Nodes.Add(Path.GetFileName(dir));
                }

                lvLocal.Items.Clear();
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    lvLocal.Items.Add(Path.GetFileName(file));
                }

                txtStatus.Text = "로컬 디렉토리 로드 성공";
            }
            catch (Exception ex)
            {
                txtStatus.Text = "로컬 디렉토리 로드 실패: " + ex.Message;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (lvLocal.SelectedItems.Count == 0) return;

            string localFile = lvLocal.SelectedItems[0].Text;
            string remotePath = txtRemoteSite.Text + "/" + localFile;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txtIP.Text + remotePath);
                request.Credentials = new NetworkCredential(txtUsername.Text, txtPassword.Text);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                using (Stream fileStream = File.OpenRead(localFile))
                using (Stream requestStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream);
                }

                txtStatus.Text = "파일 업로드 성공";
            }
            catch (Exception ex)
            {
                txtStatus.Text = "파일 업로드 실패: " + ex.Message;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (lvRemote.SelectedItems.Count == 0) return;

            string remoteFile = lvRemote.SelectedItems[0].Text;
            string localPath = Path.Combine("C:\\", remoteFile);

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txtIP.Text + remoteFile);
                request.Credentials = new NetworkCredential( txtUsername.Text, txtPassword.Text);
                request.Method= WebRequestMethods.Ftp.DownloadFile;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (Stream localFileStream = File.Create(localPath))
                {
                    responseStream.CopyTo(localFileStream);
                }

                txtStatus.Text = "파일 다운로드 성공";
            }
            catch (Exception ex)
            {
                txtStatus.Text = "파일 다운로드 실패: " + ex.Message;
            }
        }
    }
}
