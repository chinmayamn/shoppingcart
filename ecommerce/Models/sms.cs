using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Net;
/// <summary>
/// Summary description for sms
/// </summary>
namespace ecommerce.Models
{
    public class sms
    {
        public static string adminsms = "9341989900";
        public static string adminemail = "kedar@prawncrunch.com";

        public sms()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string SendSMS(string MobNum, string SMS)
        {
            try
            {
                string message = SMS;
                string url = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=Sales@farmfreshprawns.com:prawncrunch.&senderID=TEST SMS&receipientno=" + MobNum + "&dcs=0&msgtxt=" + SMS + "&state=4";



                WebRequest request = WebRequest.Create(url);
                request.Method = "Get";
                request.ContentType = "text/xml";
                WebResponse response = request.GetResponse();
                System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());
                string str = reader.ReadToEnd();
                string[] arr = null;
                //arr = str.Split(",");
                arr = str.Split(',');

                //string res = arr[0];
                //string resurl = "http://xlentpages.biz/fetchdlr.php?msgid=" + res;
                //WebRequest request1 = WebRequest.Create(resurl);
                //request1.Method = "Get";
                //request1.ContentType = "text/xml";
                //WebResponse response1 = request1.GetResponse();
                //System.IO.StreamReader reader1 = new System.IO.StreamReader(response1.GetResponseStream());
                //string str1 = reader1.ReadToEnd();
                return "Done";
            }
            catch (Exception ex)
            {
                return "no";
            }
        }
    }
}