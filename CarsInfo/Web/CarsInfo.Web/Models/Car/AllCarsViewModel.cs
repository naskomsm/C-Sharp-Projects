﻿namespace CarsInfo.Web.Models.Car
{
    using CarsInfo.Services.Models.Car;
    using System;
    using System.Collections.Generic;

    public class AllCarsViewModel
    {
        public IEnumerable<CarListingServiceModel> Cars { get; set; }

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