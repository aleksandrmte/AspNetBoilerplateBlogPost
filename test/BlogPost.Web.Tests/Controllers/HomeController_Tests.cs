using System.Threading.Tasks;
using BlogPost.Models.TokenAuth;
using BlogPost.Web.Controllers;
using Shouldly;
using Xunit;

namespace BlogPost.Web.Tests.Controllers
{
    public class HomeController_Tests: BlogPostWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}