using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace FileSpaceMonitor.Tools.SlackMessaging
{
    public class SlackClient
    {
        #region fields/properties

        private Uri _uri;
        private Encoding _encoding = new UTF8Encoding();

        #endregion

        #region .ctor
        
        /// <summary>
        /// Default constructor gets url from app.config
        /// </summary>
        public SlackClient()
        {
            _uri = new Uri(ConfigurationManager.AppSettings.Get("SlackUrl"));
        }

        /// <summary>
        /// Constructor that allows url to be passed
        /// </summary>
        /// <param name="urlWithAccessToken"></param>
        public SlackClient(string urlWithAccessToken)
        {
            _uri = new Uri(urlWithAccessToken);
        }

        #endregion

        #region PostMethod

        /// <summary>
        /// Posts the message to slack.
        /// </summary>
        /// <param name="text">message to send</param>
        /// <param name="username">username to post with</param>
        /// <param name="channel">channel to post to</param>
        public void PostMessage(string text, string username, string channel)
        {
            Payload payload = new Payload() {Channel = channel, Username = username, Text = text};
            PostMessage(payload);
        }

        /// <summary>
        /// Posts the message to slack
        /// </summary>
        /// <param name="payload">Json Payload</param>
        public void PostMessage(Payload payload)
        {
            string payloadJson = JsonConvert.SerializeObject(payload);
            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();
                data["payload"] = payloadJson;

                var response = client.UploadValues(_uri, "POST", data);
                string responseText = _encoding.GetString(response);
            }
        }

        #endregion
    }
}
