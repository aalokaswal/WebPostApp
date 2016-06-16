using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPosts.BusinnesLogic;
using WebPosts.Model;
using WebPosts.ViewModel;

namespace WebPostTests
{
    [TestClass]
    public class TestViewModel
    {
        WebPost expectedWebPost;
        List<WebPost> expectedWebPostList;
        User expecteduser;
        Mock<IWebPostBL> mockWebPostBl = new Mock<IWebPostBL>();


        [TestMethod]
        public void TestLoadAllWebPost()
        {

            expectedWebPost = new WebPost();
            expectedWebPost.id = 1;
            expectedWebPost.title = "test";
            expectedWebPost.userId = 2;
            expectedWebPost.body = "test";

            expectedWebPostList = new List<WebPost>();
            expectedWebPostList.Add(new WebPost { id = 1, title = "testTitle1" });
            expectedWebPostList.Add(new WebPost { id = 2, title = "testTitle2" });

            mockWebPostBl.Setup(m => m.GetAllWebPost()).Returns(Task.FromResult(expectedWebPostList));

            WebpostsViewModel viewModel = new WebpostsViewModel(mockWebPostBl.Object);

            viewModel.LoadWebPosts();

            var result = viewModel.WebPostList;

            Assert.AreEqual(result, expectedWebPostList);  

        }

        [TestMethod]
        public void TestDisPlayWebPostContent()
        {
            expecteduser = new User();
            expecteduser.id = 1;
            expecteduser.username = "alok";
            expecteduser.name = "alokaswal";
            expecteduser.email = "alok@gmail.com";

            expectedWebPost = new WebPost();
            expectedWebPost.id = 1;
            expectedWebPost.title = "test";
            expectedWebPost.userId = 2;
            expectedWebPost.body = "test";

            string expectedWebPostContent = "testWebPostContenet";
            string expectedWebPostCommtContent = "testwebpostcommentcontent";

            mockWebPostBl.Setup(m => m.GetWebPostContentById(It.IsAny<string>())).Returns(Task.FromResult(expectedWebPostContent));

            mockWebPostBl.Setup(m => m.GetWebPostCommentContent(It.IsAny<string>())).Returns(Task.FromResult(expectedWebPostCommtContent));

            mockWebPostBl.Setup(m => m.GetUserById(It.IsAny<string>())).Returns(Task.FromResult(expecteduser));

            WebpostsViewModel viewModel = new  WebpostsViewModel(mockWebPostBl.Object);

            viewModel.DisPlayWebPostContent(expectedWebPost);

            var webpostContentResult = viewModel.WebPostContent;

            var webpostCommentContentResult = viewModel.WebPostComment;

            var useridResult = viewModel.UserId;

            var userNameResult = viewModel.UserName;

            var userEmailResult = viewModel.UserEmail;

            Assert.AreEqual(useridResult, expecteduser.id.ToString());

            Assert.AreEqual(userNameResult, expecteduser.name);

            Assert.AreEqual(userEmailResult, expecteduser.email); 

            Assert.AreEqual(webpostContentResult, expectedWebPostContent);

            Assert.AreEqual(webpostCommentContentResult, expectedWebPostCommtContent); 
        }
    }

}
