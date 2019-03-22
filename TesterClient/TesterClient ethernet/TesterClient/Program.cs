using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace TesterClient
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new auth());
        }
    }
    class JsonSer
    {
        public Json[] Jsons { get; set; }
    }
    class Json
    {
        public string group { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public string qust { get; set; }
        public string answ { get; set; }
    }
    public class RootObject
    {
        public List<List<string>> answers { get; set; }
        public List<List<string>> quetsions { get; set; }
        public List<List<string>> tests_list { get; set; }
        public List<int> usr_answs { get; set; }
        public int time { get; set; }
        public int ended { get; set; }
    }
    class Requests
    {
        public static string token = null;
        public static string tests_list = null;
        public static string qst = null;
        public static string ans = null;
        public static int test_lenght = 0;
        public static int test_timer = 0;
        public static int ended = 0;
        public static int red = 0;
        public static int green = 0;
        public static List<int> usr_answs = null;
        public static string POST(string Url, string Request, string Data)
        {
            Json jsonSer = new Json();
            switch (Request)
            {
                case "auth":
                    jsonSer.group = $"{Data.Split(',')[0]}";
                    jsonSer.name = $"{Data.Split(',')[1]}";
                    jsonSer.password = $"{Data.Split(',')[2]}";
                    jsonSer.token = $"";
                    jsonSer.qust = $"";
                    jsonSer.answ = $"";
                    break;
                case "test_timer":
                    jsonSer.group = $"";
                    jsonSer.name = $"";
                    jsonSer.password = $"";
                    jsonSer.token = $"{Data.Split(',')[0]}";
                    jsonSer.qust = $"";
                    jsonSer.answ = $"";
                    break;
                case "send_answ":
                    jsonSer.group = $"";
                    jsonSer.name = $"";
                    jsonSer.password = $"";
                    jsonSer.token = $"{Data.Split(',')[0]}";
                    jsonSer.qust = $"{Data.Split(',')[1]}";
                    jsonSer.answ = $"{Data.Split(',')[2]}";
                    break;
                case "end_test":
                    jsonSer.group = $"";
                    jsonSer.name = $"";
                    jsonSer.password = $"";
                    jsonSer.token = $"{Data.Split(',')[0]}";
                    jsonSer.qust = $"";
                    jsonSer.answ = $"";
                    break;
                default:
                    jsonSer.group = $"";
                    jsonSer.name = $"";
                    jsonSer.password = $"";
                    jsonSer.token = $"";
                    jsonSer.qust = $"";
                    jsonSer.answ = $"";
                    break;
            }
            string data = JsonConvert.SerializeObject(jsonSer);
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            WebRequest request = WebRequest.Create(Url + Request);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = null;
            try
            {
                dataStream = request.GetRequestStream();
            }
            catch
            {
                return "False";
            }
            dataStream.Write(byteArray, 0, byteArray.Length);
            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch
            {
                return "False";
            }
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string json = reader.ReadToEnd();
            Json jsonDeSer = JsonConvert.DeserializeObject<Json>(json);
            response.Close();
            switch (Request)
            {
                case "auth":
                    token = jsonDeSer.token;
                    return token;
                case "send_answ":
                    return jsonDeSer.answ;
                case "test_timer":
                    RootObject jsonDeSerR = JsonConvert.DeserializeObject<RootObject>(json);
                    test_timer = jsonDeSerR.time;
                    return "True";
                default:
                    return "Error";
            }
        }
        public static string GET(string url, string req, string token, string test)
        {
            WebRequest request = null;
            switch (req)
            {
                case "test_list":
                    request = WebRequest.Create(url + req + "?token=" + token);
                    break;
                case "get_test":
                    request = WebRequest.Create(url + req + "?token=" + token + "&test=" + test);
                    break;
                default:
                    return "False";
            }
            request.Method = "GET";
            request.ContentType = "application/json";

            WebResponse resp = null;
            try
            {
                resp = request.GetResponse();
            }
            catch
            {
                return "False";
            }
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string json = sr.ReadToEnd();
            byte[] jsonbyte = Encoding.UTF8.GetBytes(json);
            RootObject jsonDeSer = JsonConvert.DeserializeObject<RootObject>(json);
            sr.Close();
            switch (req)
            {
                case "test_list":
                    for (int i = 0; i < jsonDeSer.tests_list.Count; i++)
                    {
                        tests_list = tests_list + jsonDeSer.tests_list[i][0];
                    }
                    return tests_list;
                case "get_test":
                    for (int i = 0; i < jsonDeSer.quetsions.Count; i++)
                    {
                        qst = qst + jsonDeSer.quetsions[i][0];
                        if (jsonDeSer.quetsions.Count - i-1 != 0)
                        {
                            qst = qst + ';';
                        }
                    }
                    for (int i = 0; i < jsonDeSer.answers.Count; i++)
                    {
                        ans = ans + jsonDeSer.answers[i][0];
                    }
                    usr_answs = jsonDeSer.usr_answs.GetRange(0,jsonDeSer.usr_answs.Count);
                    test_lenght = jsonDeSer.quetsions.Count();
                    test_timer = jsonDeSer.time;
                    ended = jsonDeSer.ended;
                    return test_lenght.ToString();
                default:
                    return "False";
            }
        }
    }
}
