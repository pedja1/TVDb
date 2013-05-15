namespace TVDb
{
    class HttpHelper
    {
        public static string HttpGet(string uri)
        {
            var req = System.Net.WebRequest.Create(uri);
            //req.Proxy = new System.Net.WebProxy(ProxyString, true); //true means no proxy
            var resp = req.GetResponse();
// ReSharper disable AssignNullToNotNullAttribute
            var sr = new System.IO.StreamReader(resp.GetResponseStream());
// ReSharper restore AssignNullToNotNullAttribute
            return sr.ReadToEnd().Trim();
        }
    }


}
