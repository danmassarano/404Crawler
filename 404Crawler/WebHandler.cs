using System.Net;

namespace _404Crawler
{
    public class WebHandler
    {
        public HttpStatusCode GetHeader(string url)
        {
            //TODO: Add handling for null or empty url added
            //TODO: Switch to async
            HttpStatusCode result = default(HttpStatusCode);

            var request = WebRequest.Create(url);
            request.Method = "HEAD";
            try
            {
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        result = response.StatusCode;
                        response.Close();
                    }
                }
            }
            catch (WebException we)
            {
                result = ((HttpWebResponse)we.Response).StatusCode;
            }

            return result;
        }
    }
}
