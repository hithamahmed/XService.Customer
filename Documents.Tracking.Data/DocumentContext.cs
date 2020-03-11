using ApplicationCore.Interfaces;
using Documents.Tracking.Data.Entities;
using General.Services.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Documents.Tracker.Data
{
    public class DocumentContext : DbContext
    {

        public DbSet<DocumentRequirements> DocRequirements { get; set; }
        public DbSet<DocIssued> DocIssued { get; set; }
        //public DbSet<ConsumerServices> ConsumerServices { get; set; }
        //public DbSet<Category> Categories { get; set; }

        //public DbSet<Product> Products { get; set; }
        //public DbSet<ProductImages> ProductImages { get; set; }




        public DocumentContext(DbContextOptions<DocumentContext> options)
         : base(options)
        {
            //this.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<Product>();
            //modelBuilder.Ignore<ProductImages>();
            //modelBuilder.Ignore<Category>();


            GeneralQueryFilter(modelBuilder);
        }

        private void GeneralQueryFilter(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<InvOrders>(entity => entity.HasQueryFilter(x => x.deleted_flag == 0 || x.deleted_flag == null));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (OnBeforeSaving())
                return base.SaveChangesAsync(cancellationToken);

            return null;

        }
        public override int SaveChanges()
        {
            if (OnBeforeSaving())
                return base.SaveChanges();
            return 0;
        }

        private bool OnBeforeSaving()
        {
            try
            {
                if (true) //(_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    var entries = ChangeTracker.Entries();
                    foreach (var entry in entries)
                    {
                        if (entry.Entity is IAuditable trackable)
                        {
                            var now = DateTime.UtcNow.AddHours(3);
                            var user = GetCurrentUser();
                            switch (entry.State)
                            {
                                case EntityState.Modified:
                                    trackable.ModifiedAt = now;
                                    trackable.ModifiedBy = user;
                                    break;

                                case EntityState.Added:
                                    trackable.CreatedAt = now;
                                    //trackable.CreatedBy = user;

                                    break;
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        private string GetCurrentUser()
        {
            return "0";
            //var httpContext = _httpContextAccessor.HttpContext;
            //if (httpContext != null)
            //{
            //    var authenticatedUserName = httpContext.User.Identity.Name;

            //    // If it returns null, even when the user was authenticated, you may try to get the value of a specific claim 
            //    var authenticatedUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
            //    // var authenticatedUserId = _httpContextAccessor.HttpContext.User.FindFirst("sub").Value

            //    // TODO use name to set the shadow property value like in the following post: https://www.meziantou.net/2017/07/03/entity-framework-core-generate-tracking-columns
            //}
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
