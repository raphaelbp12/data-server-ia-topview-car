using System;
using System.Net.Http;

namespace BaseClient
{
    public class FlickrBaseClient
    {
        public System.Net.Http.HttpClient Client { get; }

        public FlickrBaseClient(System.Net.Http.HttpClient client)
        {
            client.BaseAddress = new Uri("https://www.flickr.com");

            Client = client;
        }
    }
}