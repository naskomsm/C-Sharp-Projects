namespace CarsInfo.Web.Models.Suspension
{
    using CarsInfo.Services.Models.Suspension;
    using System;
    using System.Collections.Generic;

    public class AllSuspensionViewModel
    {
        public IEnumerable<SuspensionListingServiceModel> Suspensions { get; set; }

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
