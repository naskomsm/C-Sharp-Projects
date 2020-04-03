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
        public async Task HeaderShouldContainElements(string element)
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
        public async Task AboutShouldContainInputElements(string element)
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
        public async Task AboutShouldContainElements(string element)
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
        public async Task IndexPageShouldContainElements(string element)
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
        public async Task IndexShouldContainElements(string element)
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
        public async Task AccountManagePageRequiresAuthorization()
        {
            var client = this.server.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
            var response = await client.GetAsync("Identity/Account/Manage");
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }

        [Theory]
        [InlineData("<div class=\"card mb-3\">")]
        [InlineData("<h5 class=\"card-title\">Buses</h5>")]
        public async Task CategoryViewShouldContainElements(string element)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/Categories/Buses");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains(element, responseContent);
        }

        [Theory]
        [InlineData("<section class=\"content-item\" id=\"comments\">")]
        [InlineData("<div class=\"container\">")]
        [InlineData("<div id=\"commentsSection\" class=\"col-md-8\">")]
        public async Task CommentShouldContainElements(string element)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/Posts/Details/1");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains(element, responseContent);
        }

        [Theory]
        [InlineData("<div class=\"row\">")]
        [InlineData("<div class=\"col-4\">")]
        [InlineData("<div class=\"row align-items-end\">")]
        public async Task PostsAllViewShouldContainElements(string element)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/Posts/All");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains(element, responseContent);
        }

        [Theory]
        [InlineData("<form method=\"get\" action=\"/Posts/All\">")]
        [InlineData("<h6 id=\"pageHeader\">Search in SellAndBuyVehicles</h6>")]
        [InlineData("<select class=\"mdb-select md-form container\" id=\"makesSelect\" name=\"make\">")]
        public async Task SearchViewShouldContainElements(string element)
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/Posts/Search");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains(element, responseContent);
        }
    }
}