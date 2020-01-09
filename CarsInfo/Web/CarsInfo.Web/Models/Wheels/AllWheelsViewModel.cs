﻿namespace CarsInfo.Web.Models.Brakes
{
    using CarsInfo.Services.Models.Wheels;
    using System;
    using System.Collections.Generic;

    public class AllWheelsViewModel
    {
        public IEnumerable<WheelsListingServiceModel> Wheels { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage => CurrentPage - 1;

        public int NextPage => CurrentPage + 1;

        public bool PreviousDisabled => this.CurrentPage == 1;

        public int Total { get; set; }

        public bool NextDisabled
        {
            get
            {
                var maxPage = Math.Ceiling((double)this.Total / 6);

                return maxPage == this.CurrentPage;
            }
        }
    }
}