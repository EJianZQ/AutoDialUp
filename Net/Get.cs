using System;
using System.Text;
using System.Net;
using System.IO;


namespace AutoDialUp.Net
{
    public class GetMethod
    {
        /// <summary>
        /// Get方法
        /// </summary>
        /// <param name="Url">欲获取的链接</param>
        /// <param name="ifSSL">是否启用Https</param>
        /// <returns></returns>
        public static string Get(string Url, bool SSL = false)
        {
            if (SSL == true)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;  //SSL证书模式
            }
            //System.GC.Collect();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Timeout = 3000; //3秒即超时,直接抛出异常
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();

                myStreamReader.Close();
                myResponseStream.Close();

                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }

                return retString;
            }
            catch
            {
                return "Error";
            }
        }

        /// <summary>
        /// Post方法
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Data"></param>
        /// <param name="Referer"></param>
        /// <returns></returns>
        public static string Post(string Url, string Data, string Referer)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.Referer = Referer;
            byte[] bytes = Encoding.UTF8.GetBytes(Data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            Stream myResponseStream = request.GetRequestStream();
            myResponseStream.Write(bytes, 0, bytes.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }
            return retString;
        }

        /// <summary>
        /// 带Authorization认证的Get方法
        /// </summary>
        public static string Get(string Url, string username, string password)
        {
            try
            {
                string usernamePassword = username + ":" + password; //格式"username:password"
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Url));
                CredentialCache cache = new CredentialCache();
                cache.Add(new Uri(Url), "Basic", new NetworkCredential(username, password));
                request.Credentials = cache;
                request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)));
                WebResponse response = request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
                string content = reader.ReadToEnd();
                //关闭文件流
                response.Close();
                receiveStream.Close();
                reader.Close();
                return content;
            }
            catch
            {
                return "Error";
            }
        }

        /// <summary>
        /// 获取网络时间
        /// </summary>
        public static string GetNetDateTime()
        {
            WebRequest request = null;
            WebResponse response = null;
            WebHeaderCollection headerCollection = null;
            string datetime = string.Empty;
            try
            {
                request = WebRequest.Create("https://www.baidu.com");
                request.Timeout = 3000;
                request.Credentials = CredentialCache.DefaultCredentials;
                response = (WebResponse)request.GetResponse();
                headerCollection = response.Headers;
                foreach (var h in headerCollection.AllKeys)
                { if (h == "Date") { datetime = headerCollection[h]; } }
                return datetime;
            }
            catch (Exception) { return datetime; }
            finally
            {
                if (request != null)
                { request.Abort(); }
                if (response != null)
                { response.Close(); }
                if (headerCollection != null)
                { headerCollection.Clear(); }
            }
        }
    }
}
