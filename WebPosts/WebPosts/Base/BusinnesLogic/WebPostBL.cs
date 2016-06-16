using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebPosts.Model;

namespace WebPosts.BusinnesLogic
{
    public class WebPostBL : IWebPostBL
    {
        string webUrl = string.Empty;

        public WebPostBL()
        {
            webUrl = "http://jsonplaceholder.typicode.com/";
        }

        public async Task<List<WebPost>> GetAllWebPost()
        {
            var url = webUrl + "posts";
            List<WebPost> webPostList = null;
            var client = new HttpClient();
            var task = client.GetAsync(url)
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  webPostList = JsonConvert.DeserializeObject<List<WebPost>>(jsonString.Result);

              });
            task.Wait();

            return webPostList;
        }

        public async Task<string> GetWebPostContentById(string id)
        {
            var url = webUrl + "posts/" + id;
            string webPostContent = null;
            var client1 = new HttpClient();
            webPostContent = await client1.GetStringAsync(url);

            return webPostContent;
        }

        public async Task<string> GetWebPostCommentContent(string id)
        {
            var url = webUrl + "posts/" + id + "/comments";
            string webPostComment = null;
            var client1 = new HttpClient();
            webPostComment = await client1.GetStringAsync(url);

            return webPostComment;
        }

        public async Task<WebPost> GetWebPost(string id)
        {
            var url = webUrl + "posts/" + id;
            WebPost webPost = null;
            var client = new HttpClient();
            var task = client.GetAsync(url)
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  webPost = JsonConvert.DeserializeObject<WebPost>(jsonString.Result);

              });
            task.Wait();

            return webPost;
        }

        public async Task<List<WebPostComment>> GetWebPostComments(string id)
        {
            var url = webUrl + "posts/" + id + "/comments";
            List<WebPostComment> webPostCommentsList = null;
            var client = new HttpClient();
            var task = client.GetAsync(url)
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  webPostCommentsList = JsonConvert.DeserializeObject<List<WebPostComment>>(jsonString.Result);

              });
            task.Wait();

            return webPostCommentsList;
        }

        public async Task<User> GetUserById(string userId)
        {
            var url = webUrl + "users/" + userId;
            User webPost = null;
            var client = new HttpClient();
            var task = client.GetAsync(url)
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  webPost = JsonConvert.DeserializeObject<User>(jsonString.Result);

              });
            task.Wait();

            return webPost;
        }

    }
}
