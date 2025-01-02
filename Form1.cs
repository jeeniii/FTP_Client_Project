using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace FTP_Client_Project
{
    public partial class FTPManager : Form
    {
        private FTPClass ftpClient;

        public FTPManager()
        {
            InitializeComponent();
            ftpClient = new FTPClass();
            ftpClient.ExceptionEvent += HandleException;

            // 기본 경로 설정
            LoadLocalDirectories("C:\\");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ftpServer = txtIP.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (ftpClient.ConnectToServer(ftpServer, username, password))
            {
                txtStatus.Text = "FTP 연결 성공";
                LoadRemoteDirectories("/");
            }
            else
            {
                txtStatus.Text = "FTP 연결 실패: " + ftpClient.LastException?.Message;
            }
        }

        private void LoadRemoteDirectories(string path)
        {
            try
            {
                var directories = ftpClient.GetDirectoryListing(path);
                tvRemote.Nodes.Clear();

                foreach (string dir in directories)
                {
                    tvRemote.Nodes.Add(dir);
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
                    FileInfo fileInfo = new FileInfo(file);
                    ListViewItem item = new ListViewItem(fileInfo.Name);
                    item.SubItems.Add(fileInfo.Length.ToString("N0") + " bytes"); // 크기 추가
                    item.SubItems.Add(fileInfo.LastWriteTime.ToString());
                    lvLocal.Items.Add(item);
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

            progressBar.Maximum = lvLocal.SelectedItems.Count;
            progressBar.Value = 0;

            foreach (ListViewItem item in lvLocal.SelectedItems)
            {
                string localFile = item.Text;
                string remotePath = txtRemoteSite.Text + "/" + localFile;

                if (ftpClient.UploadFile(localFile, remotePath))
                {
                    txtStatus.Text = $"파일 {localFile} 업로드 성공";
                }
                else
                {
                    txtStatus.Text = $"파일 {localFile} 업로드 실패: {ftpClient.LastException?.Message}";
                }

                progressBar.Value++;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (lvRemote.SelectedItems.Count == 0) return;

            progressBar.Maximum = lvRemote.SelectedItems.Count;
            progressBar.Value = 0;

            foreach (ListViewItem item in lvRemote.SelectedItems)
            {
                string remoteFile = item.Text;
                string localPath = Path.Combine("C:\\", remoteFile);

                if (ftpClient.DownloadFile(remoteFile, localPath))
                {
                    txtStatus.Text = $"파일 {remoteFile} 다운로드 성공";
                }
                else
                {
                    txtStatus.Text = $"파일 {remoteFile} 다운로드 실패: {ftpClient.LastException?.Message}";
                }
            }

            progressBar.Value++;
        }

        private void HandleException(string locationID, Exception ex)
        {
            txtStatus.Text = $"Error at {locationID}: {ex.Message}";

            //로그 파일 저장
            string logPath = Path.Combine(Environment.CurrentDirectory, "error_log.txt");
            File.AppendAllText(logPath, $"{DateTime.Now}: {locationID} - {ex.Message}\n");
        }

        private void SyncDirectories(string localPath, string remotePath)
        {
            try
            {
                string[] localFiles = Directory.GetFiles(localPath);
                string[] localDirectories = Directory.GetDirectories(localPath);

                foreach (var file in localFiles)
                {
                    string fileName = Path.GetFileName(file);
                    string remoteFilePath = remotePath + "/" + fileName;

                    if (ftpClient.UploadFile(file, remoteFilePath))
                    {
                        txtStatus.Text = $"동기화: {fileName} 업로드 성공";
                    }
                    else
                    {
                        txtStatus.Text = $"동기화: {fileName} 업로드 실패";
                    }
                }

                foreach (string dir in localDirectories)
                {
                    string dirName = Path.GetFileName(dir);
                    string remoteDirPath = remotePath + "/" + dirName;

                    ftpClient.CreateRemoteDirectory(remoteDirPath); //원격 디렉토리 생성
                    SyncDirectories(dir, remoteDirPath); //재귀 호출
                }
            }
            catch (Exception ex)
            {
                txtStatus.Text = $"동기화 중 오류 발생: {ex.Message}";
            }

            
            
        }
    }
}
