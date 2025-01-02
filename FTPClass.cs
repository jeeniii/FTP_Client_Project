using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace FTP_Client_Project
{
    public class FTPClass
    {
        public delegate void ExceptionEventHandler(string locationID, Exception ex);
        public event ExceptionEventHandler ExceptionEvent;
        public Exception LastException { get; private set; }

        private string ftpServer;
        private string username;
        private string password;

        // 서버 연결
        public bool ConnectToServer(string server, string user, string pass)
        {
            ftpServer = server;
            username = user;
            password = pass;

            try
            {
                string url = $"ftp://{ftpServer}/";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return true; // 연결 성공
                }
            }
            catch (Exception ex)
            {
                LastException = ex;
                ExceptionEvent?.Invoke(nameof(ConnectToServer), ex);
                return false; // 연결 실패
            }
        }

        // 디렉토리 목록 가져오기
        public List<string> GetDirectoryListing(string path)
        {
            var directories = new List<string>();
            try
            {
                string url = $"ftp://{ftpServer}/{path}".Replace("\\", "/");
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    while (!reader.EndOfStream)
                    {
                        directories.Add(reader.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                LastException = ex;
                ExceptionEvent?.Invoke(nameof(GetDirectoryListing), ex);
            }

            return directories;
        }

        // 파일 업로드
        public bool UploadFile(string localFilePath, string remoteFilePath)
        {
            try
            {
                string url = $"ftp://{ftpServer}/{remoteFilePath}".Replace("\\", "/");
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                using (FileStream fileStream = new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
                using (Stream requestStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream);
                }

                return true; // 업로드 성공
            }
            catch (Exception ex)
            {
                LastException = ex;
                ExceptionEvent?.Invoke(nameof(UploadFile), ex);
                return false; // 업로드 실패
            }
        }

        // 파일 다운로드
        public bool DownloadFile(string remoteFilePath, string localFilePath)
        {
            try
            {
                string url = $"ftp://{ftpServer}/{remoteFilePath}".Replace("\\", "/");
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (FileStream localFileStream = new FileStream(localFilePath, FileMode.Create))
                {
                    responseStream.CopyTo(localFileStream);
                }

                return true; // 다운로드 성공
            }
            catch (Exception ex)
            {
                LastException = ex;
                ExceptionEvent?.Invoke(nameof(DownloadFile), ex);
                return false; // 다운로드 실패
            }
        }
        public void CreateRemoteDirectory(string remoteDirectoryPath)
        {
            try
            {
                // FTP URL 생성
                string url = $"ftp://{ftpServer}/{remoteDirectoryPath}".Replace("\\", "/");

                // FtpWebRequest 객체 생성
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(username, password);

                // 요청 실행
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    // 디렉토리 생성 성공
                }
            }
            catch (WebException ex)
            {
                if (ex.Response is FtpWebResponse response &&
                    response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    // 디렉토리가 이미 존재하는 경우 예외 무시
                }
                else
                {
                    // 다른 예외 처리
                    LastException = ex;
                    ExceptionEvent?.Invoke(nameof(CreateRemoteDirectory), ex);
                }
            }
            catch (Exception ex)
            {
                LastException = ex;
                ExceptionEvent?.Invoke(nameof(CreateRemoteDirectory), ex);
            }
        }

    }
}
