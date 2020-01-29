using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using NLog;

namespace _404Crawler
{
    /// <summary>
    /// Link object stores all information about a given link 
    /// </summary>
    public class Link
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public string Name;
        public string URL;
        public bool Passed;
        public bool Internal;
        public bool UsesHTTPS;
        public bool SSLIsValid;

        /// <summary>
        /// Constructor class for link object
        /// </summary>
        /// <param name="name">Name of link before any string manupulation is performed</param>
        /// <param name="url">URL of link - might be different if provided link is relative</param>
        /// <param name="passed">Whether the link has been successfully tested</param>
        /// <param name="isInternal">Whether the link is internal to the site, or external</param>
        /// <param name="usesHTTPS">Whether the link attempts an HTTPS connection</param>
        public Link(string name, string url, bool passed, bool isInternal, bool usesHTTPS)
        {
            Name = name;
            URL = url;
            Passed = passed;
            Internal = isInternal;
            UsesHTTPS = usesHTTPS;
            SSLIsValid = false;

            if (usesHTTPS && !isInternal && passed)
            {
                HttpWebRequest request = WebRequest.CreateHttp(url);
                request.ServerCertificateValidationCallback += ValidateCertificate;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) { }
            }
        }

        /// <summary>
        /// Checks if the SSL certificate of a website is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
        private bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                SSLIsValid = true;
                Logger.Info("Certificate OK");
                return true;
            }

            Logger.Warn($"Certificate ERROR : {URL}");
            return false;
        }
    }
}
