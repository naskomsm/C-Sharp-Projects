namespace Sabv.Web.Tests
{
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Testing;

    using Xunit;

    public class WebTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> server;

        public WebTests(WebApplicationFactory<Startup> server)
        {
            this.server = server;
        }

        [Theory]
        [InlineData("<a class=\"nav-link text-dark\" href=\"/\">")]
        [InlineData("<a class=\"nav-link text-dark\" href=\"/Posts/Search\">")]
        [InlineData("<a class=\"nav-link text-dark\" href=\"/Posts/Create\">")]
        [InlineData("<a class=\"nav-link text-dark\" href=\"/Home/About\">")]
        [InlineData("<a class=\"nav-link text-dark\" href=\"/Chat/Main\">")]
        [InlineData("<a class=\"nav-link text-dark\" href=\"/Identity/Account/Register\">")]
        [InlineData("<a class=\"nav-link text-dark\" href=\"/Identity/Account/Login\">")]
        public async Task HeaderShouldContainUlWithAllLis(string element)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains(element, responseContent);
        }

        [Theory]
        [InlineData("<input type=\"text\" id=\"fromName\" name=\"fromName\" class=\"form-control\">")]
        [InlineData("<input type=\"text\" id=\"from\" name=\"from\" class=\"form-control\">")]
        [InlineData("<input type=\"text\" id=\"subject\" name=\"subject\" class=\"form-control\">")]
        [InlineData("<textarea type=\"text\" id=\"message\" name=\"message\" rows=\"2\" class=\"form-control md-textarea\">")]
        public async Task AboutShouldContainAllFormFields(string element)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/Home/About");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains(element, responseContent);
        }

        [Theory]
        [InlineData("<i class=\"fa fa-location-arrow\"></i>")]
        [InlineData("<p>Sofia, Bulgaria</p>")]
        [InlineData("<i class=\"fa fa-mobile\"></i>")]
        [InlineData("<p>+359 899 11 5617</p>")]
        [InlineData("<i class=\"fa fa-envelope-square\"></i>")]
        [InlineData("<p>naskokolev00@gmail.com</p>")]
        public async Task AboutShouldContainUlLiElements(string element)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/Home/About");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains(element, responseContent);
        }

        [Fact]
        public async Task IndexPageShouldReturnStatusCode200WithTitle()
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("<title>", responseContent);
        }

        [Fact]
        public async Task AccountManagePageRequiresAuthorization()
        {
            var client = this.server.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
            var response = await client.GetAsync("Identity/Account/Manage");
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }
    }
}
