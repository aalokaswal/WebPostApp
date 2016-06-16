using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPosts.Model;

namespace WebPosts.BusinnesLogic
{
    public interface IWebPostBL
    {
        Task<List<WebPost>> GetAllWebPost();

        Task<string> GetWebPostContentById(string id);

        Task<string> GetWebPostCommentContent(string id);

        Task<WebPost> GetWebPost(string id);

        Task<List<WebPostComment>> GetWebPostComments(string id);

        Task<User> GetUserById(string userId);
    }
}
