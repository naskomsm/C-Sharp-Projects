namespace Sabv.Web.Tests
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Sabv.Data.Models;
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
        public async Task IndexShouldContainCarouselDiv()
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("<div id=\"carouselExampleIndicators\" class=\"carousel slide my-4\" data-ride=\"carousel\" width=\"900\" height=\"350\">", responseContent);
        }

        [Theory]
        [InlineData("<a href=\"Categories/Buses\" class=\"list-group-item\">")]
        [InlineData("<a href=\"Categories/Trucks\" class=\"list-group-item\">")]
        [InlineData("<a href=\"Categories/Motorcycles\" class=\"list-group-item\">")]
        [InlineData("<a href=\"Categories/Cars and jeeps\" class=\"list-group-item\">")]
        public async Task IndexPageShouldContainCategoriesLis(string element)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains(element, responseContent);
        }

        [Theory]
        [InlineData("<a href=\"/Posts/Details/1\">")]
        [InlineData("<a href=\"/Posts/Details/2\">")]
        [InlineData("<a href=\"/Posts/Details/3\">")]
        public async Task IndexShouldContainAElementAboutPost(string element)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/");
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
        public async Task ChatPageShouldContainChatDiv()
        {
            var client = this.server.CreateClient();

            // Should simulate login here...
            var username = "GOD";
            var password = "123456";
            var formContent = new FormUrlEncodedContent(new[]
            {
                 new KeyValuePair<string, string>("__RequestVerificationToken", "CfDJ8OwyFtW952ZMjA-vuvOTnzfLT1uBrBfhZVcsGz3buwf11ePNEnz0YjY07XQEwQ8GhdRTWvR3qR77fwJ-_BF2BX8k-EmeiGQs4Mbh5_SjSlEJPdsX8PeRvhdGZ6pugYml966QYkEgB6cKS4hEcndOMAk"),
                 new KeyValuePair<string, string>("Input.UserName", username),
                 new KeyValuePair<string, string>("Input.Password", password),
                 new KeyValuePair<string, string>("Input.RememberMe", "false"),
            });
            var responseMessage = await client.PostAsync("/Identity/Account/Login", formContent);
            var response = await client.GetAsync("/Chat/Main");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("<div id=\"chat\">", responseContent);
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
