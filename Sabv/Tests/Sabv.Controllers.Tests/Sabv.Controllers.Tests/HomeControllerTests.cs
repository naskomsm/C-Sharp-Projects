namespace Sabv.Controllers.Tests
{
    using MyTested.AspNetCore.Mvc;
    using Sabv.Data.Models;
    using Sabv.Web.Controllers;
    using Sabv.Web.ViewModels.Home;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class HomeControllerTests
    {
        public List<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category(),
                new Category(),
            };
        }

        public List<Image> GetImages()
        {
            return new List<Image>()
            {
                new Image(),
                new Image(),
            };
        }

        public List<Post> GetPosts()
        {
            return new List<Post>()
            {
                new Post(),
                new Post(),
            };
        }

        [Fact]
        public void IndexShouldReturnProperViewWithData()
        {
            MyController<HomeController>
                .Instance(i => i.WithRouteData(GetCategories()).WithRouteData(GetImages()).WithRouteData(GetPosts()))
                .Calling(c => c.Index())
                .ShouldReturn()
                .View(v => v.WithModelOfType<IndexViewModel>()
                .Passing(model => model.Categories = GetCategories()));


        }
    }
}
