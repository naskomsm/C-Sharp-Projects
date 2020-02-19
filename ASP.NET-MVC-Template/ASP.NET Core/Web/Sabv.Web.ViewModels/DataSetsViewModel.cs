﻿namespace Sabv.Web.ViewModels
{
    using Sabv.Web.ViewModels.Posts;

    public class DataSetsViewModel
    {
        public string[] Categories { get; set; }

        public string[] Cities { get; set; }

        public string[] Years { get; set; }

        public string[] Colors { get; set; }

        public VehicleFeatures Features { get; set; }

        public string[] CarTypeCategories { get; set; }
    }
}