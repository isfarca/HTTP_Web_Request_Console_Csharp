using System;
using System.IO;
using System.Net;
using System.Text;

namespace HTTP_Web_Request
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare Variables
            string PostData = "PARAMETER1=VALUE1&amp;PARAMETER2=VALUE2";
            ASCIIEncoding Encoding = new ASCIIEncoding();
            byte[] ASCIIPostData = Encoding.GetBytes(PostData);

            HttpWebRequest HTTPRequest = (HttpWebRequest)WebRequest.Create("http://trainex24.de/bm-trainex/pda/");
            Stream Request;

            HttpWebResponse HTTPResponse;
            Stream Response;

            StreamReader Reader;
            string Output;

            HTTPRequest.Method = "POST";
            HTTPRequest.Accept = "text/plain";
            HTTPRequest.ContentType = "application/x-www-form-urlencoded";
            HTTPRequest.ContentLength = ASCIIPostData.Length;

            // Prepare request and send 
            Request = HTTPRequest.GetRequestStream();
            Request.Write(ASCIIPostData, 0, ASCIIPostData.Length);

            // Get the response 
            HTTPResponse = (HttpWebResponse)HTTPRequest.GetResponse();
            Response = HTTPResponse.GetResponseStream();

            // Select
            Reader = new StreamReader(Response);
            Output = Reader.ReadToEnd();

            Console.Write(Output);
            Console.ReadKey();
        }
    }
}