﻿namespace Sabv.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Sabv.Data.Common.Models;

    public class Post : BaseModel<string>, IDeletableEntity
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();

            // Collections
            this.Images = new HashSet<Image>();
        }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        // Post specifics
        [Required]
        [MaxLength(DataValidation.Common.MaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(DataValidation.Post.MinPrice, DataValidation.Post.MaxPrice)]
        public decimal Price { get; set; }

        [MaxLength(DataValidation.Post.MaxDescriptionLength)]
        public string Description { get; set; }

        public bool IsFavourite { get; set; }

        [Required]
        [RegularExpression(@"08[789]\d{7}", ErrorMessage = "Invalid phone number!")]
        public string PhoneNumber { get; set; }

        // Relations
        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        [Required]
        public string MainInfoId { get; set; }

        public virtual MainInfo MainInfo { get; set; }

        [Required]
        public string AdditionalInfoId { get; set; }

        public virtual AdditionalInfo AdditionalInfo { get; set; }

        [Required]
        public string VehicleCategoryId { get; set; }

        public virtual VehicleCategory VehicleCategory { get; set; }

        [Required]
        public string PostCategoryId { get; set; }

        public virtual PostCategory PostCategory { get; set; }
    }
}
