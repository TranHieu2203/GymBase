﻿using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;

namespace GymApp.Model.Model
{
    public class GymAppContext : DbContext
    {
       

        public GymAppContext()
            : base("Name=GymAppContext")
        {
            //có rồi thì không create nữa
            //Database.SetInitializer<GymAppContext>(new CreateDatabaseIfNotExists<GymAppContext>());
            // bỏ tự động migrate database
            //Database.SetInitializer<GymAppContext>(null);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppGroupUser> AppGroupUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Credential> Credentials { get; set; }


        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
               // IAuditableEntity entity = entry.Entity as IAuditableEntity;
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    var userId = HttpContext.Current.Session[Common.CommonConst.UserName];
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedBy = userId.ToString();
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = userId.ToString();
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            try
            {
                // Không tự create các bảng sau này nữa
                Database.SetInitializer<GymAppContext>(null);
                //base.OnModelCreating(modelBuilder);

                var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(type => !string.IsNullOrEmpty(type.Namespace))
                    .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                                   && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
                foreach (var type in typesToRegister)
                {
                    dynamic configurationInstance = Activator.CreateInstance(type);
                    modelBuilder.Configurations.Add(configurationInstance);
                }
                
                //modelBuilder.Entity<Book>()
                //    .Ignore(p => p.StringSourceType).Ignore(p => p.StringState);
            }
            catch
            {
                
            }
            base.OnModelCreating(modelBuilder);
        }
    }

}
