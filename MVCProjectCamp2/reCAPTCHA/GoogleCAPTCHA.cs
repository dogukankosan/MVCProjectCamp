using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

namespace MVCProjectCamp2.reCAPTCHA
{
    public class GoogleCAPTCHA
    {
        public bool Success { get; set; }
        public List<string> ErrorCodes { get; set; }
        public static bool Validate(string encoresponse)
        {
            try
            {
                if (string.IsNullOrEmpty(encoresponse)) return false;
                WebClient client = new WebClient();
                string secret = "6Le4BjceAAAAANiL8SiDBucuoPfa14_Ncf63uotO";
                if (string.IsNullOrEmpty(secret)) return false;
                string googledow = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, encoresponse));
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var recap = serializer.Deserialize<GoogleCAPTCHA>(googledow);
                return recap.Success;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}