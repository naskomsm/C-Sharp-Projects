namespace Sabv.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Sabv.Data.Common.Models;
    using Sabv.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<AdditionalInfo> AdditionalInfos { get; set; }

        public DbSet<MainInfo> MainInfos { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostCategory> PostCategories { get; set; }

        public DbSet<VehicleCategory> VehicleCategories { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            ConfigureUserIdentityRelations(builder);
            ConfigurePostRelations(builder);
            ConfigureAdditionalInfoRelations(builder);
            ConfigureMainInfoRelations(builder);
            ConfigureImageRelations(builder);
            ConfigurePostCategoryRelations(builder);
            ConfigureVehicleCategoryRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void ConfigureUserIdentityRelations(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigurePostRelations(ModelBuilder builder)
        {
            builder.Entity<Post>()
                 .HasMany(p => p.Images)
                 .WithOne(i => i.Post)
                 .HasForeignKey(i => i.PostId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasOne(p => p.MainInfo)
                .WithMany(mi => mi.Posts)
                .HasForeignKey(p => p.MainInfoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasOne(p => p.AdditionalInfo)
                .WithMany(ai => ai.Posts)
                .HasForeignKey(p => p.AdditionalInfoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasOne(p => p.VehicleCategory)
                .WithMany(vc => vc.Posts)
                .HasForeignKey(p => p.VehicleCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasOne(p => p.PostCategory)
                .WithMany(pc => pc.Posts)
                .HasForeignKey(p => p.PostCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureAdditionalInfoRelations(ModelBuilder builder)
        {
            builder.Entity<AdditionalInfo>()
                .HasMany(ai => ai.Posts)
                .WithOne(p => p.AdditionalInfo)
                .HasForeignKey(p => p.AdditionalInfoId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureMainInfoRelations(ModelBuilder builder)
        {
            builder.Entity<MainInfo>()
               .HasMany(mi => mi.Posts)
               .WithOne(p => p.MainInfo)
               .HasForeignKey(p => p.MainInfoId)
               .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureImageRelations(ModelBuilder builder)
        {
            builder.Entity<Image>()
                .HasOne(i => i.Post)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigurePostCategoryRelations(ModelBuilder builder)
        {
            builder.Entity<PostCategory>()
                .HasMany(pc => pc.Posts)
                .WithOne(p => p.PostCategory)
                .HasForeignKey(p => p.PostCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureVehicleCategoryRelations(ModelBuilder builder)
        {
            builder.Entity<VehicleCategory>()
                .HasMany(vc => vc.Posts)
                .WithOne(p => p.VehicleCategory)
                .HasForeignKey(p => p.VehicleCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
