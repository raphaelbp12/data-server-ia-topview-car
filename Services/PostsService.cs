using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostsApi.Models;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Posts.Service
{
    public static class PostsService
    {
        public static async Task<FeedDTO> GetFeed()
        {
            FeedDTO feed = new FeedDTO();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://www.flickr.com/services/feeds/photos_public.gne?format=json"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    string pureJson = Regex.Replace(apiResponse, @"^.+?\(|\)$", "");
                    feed = JsonConvert.DeserializeObject<FeedDTO>(pureJson);
                }
            }
            return feed;
        }
    }
}