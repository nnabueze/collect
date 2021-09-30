using ErcasCollect.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ErcasCollect.DataAccess.Repository
{
    public class WebCallService : IWebCallService
    {
        public async Task<string> NIBSSWebCall(string url, string parameter)
        {

            string responseText = string.Empty;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest httpWebReq = (HttpWebRequest)WebRequest.Create(url);
            httpWebReq.ContentType = "text/xml";
            httpWebReq.Accept = "application/xml";
            httpWebReq.Method = "POST";

            using (StreamWriter streamWriter = new StreamWriter(await httpWebReq.GetRequestStreamAsync()))
            {

                streamWriter.Write(parameter);
                streamWriter.Flush();
            }

            using (HttpWebResponse httpResponse = (HttpWebResponse)await httpWebReq.GetResponseAsync())
            {
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    return responseText;
                }

                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseText = streamReader.ReadToEnd();
                }
            }


            return responseText;

        }

        public async Task<string> GetWebCall(string url)
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return strResponseValue;
                }

                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    strResponseValue = streamReader.ReadToEnd();
                }
            }

            return strResponseValue;
        }

        public async Task<string> NIBSSWebCall2(string url, string parameter)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            byte[] bytes;
            bytes = Encoding.ASCII.GetBytes(parameter);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                return responseStr;
            }
            return null;

        }

        public async Task<HttpStatusCode> PostWebCall(string url, string parameter)
        {

            string responseText = string.Empty;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest httpWebReq = (HttpWebRequest)WebRequest.Create(url);
            httpWebReq.ContentType = "application/json";
            httpWebReq.Accept = "application/json";
            httpWebReq.Method = "POST";

            using (StreamWriter streamWriter = new StreamWriter(await httpWebReq.GetRequestStreamAsync()))
            {

                streamWriter.Write(parameter);
                streamWriter.Flush();
            }

            using (HttpWebResponse httpResponse = (HttpWebResponse)await httpWebReq.GetResponseAsync())
            {
                return httpResponse.StatusCode;
            }
        }

        public async Task<string> PostDataCall(string url, string parameter)
        {

            string responseText = string.Empty;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest httpWebReq = (HttpWebRequest)WebRequest.Create(url);
            httpWebReq.ContentType = "application/json";
            httpWebReq.Accept = "application/json";
            httpWebReq.Method = "POST";

            using (StreamWriter streamWriter = new StreamWriter(await httpWebReq.GetRequestStreamAsync()))
            {

                streamWriter.Write(parameter);
                streamWriter.Flush();
            }

            using (HttpWebResponse httpResponse = (HttpWebResponse)await httpWebReq.GetResponseAsync())
            {
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    return responseText;
                }

                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseText = streamReader.ReadToEnd();
                }
            }


            return responseText;

        }


        public async Task<string> PostXmlDataCall(string url, string parameter)
        {

            string responseText = string.Empty;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest httpWebReq = (HttpWebRequest)WebRequest.Create(url);
            httpWebReq.ContentType = "application/xml";
            httpWebReq.Accept = "application/xml";
            httpWebReq.Method = "POST";

            using (StreamWriter streamWriter = new StreamWriter(await httpWebReq.GetRequestStreamAsync()))
            {

                streamWriter.Write(parameter);
                streamWriter.Flush();
            }

            using (HttpWebResponse httpResponse = (HttpWebResponse)await httpWebReq.GetResponseAsync())
            {
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    return responseText;
                }

                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseText = streamReader.ReadToEnd();
                }
            }


            return responseText;

        }
    }
}
