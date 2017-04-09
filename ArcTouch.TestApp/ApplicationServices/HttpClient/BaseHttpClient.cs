using System;
using System.Net.Http;

namespace ArcTouch.TestApp
{
    /// <summary>
    /// Singleton for HttpClient.
    /// </summary>
    public sealed class BaseHttpClient
    {
        static volatile BaseHttpClient instance;
        static object syncLock = new object();
        static HttpClient httpClient;

        BaseHttpClient()
        {
            if (App.AppHttpClient == null)
            {
                httpClient = new HttpClient
                {
                    Timeout = TimeSpan.FromSeconds(40),
                    BaseAddress = new Uri(Constants.BaseURLAddress)
                };
            }
        }

        public static HttpClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                            instance = new BaseHttpClient();
                    }
                }
                return httpClient;
            }
        }
    }
}