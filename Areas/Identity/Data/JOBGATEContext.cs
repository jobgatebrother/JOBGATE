using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JOBGATE.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JOBGATE.Models;

namespace JOBGATE.Data
{
    public class JOBGATEContext : IdentityDbContext<UserAccount>
    {
        public JOBGATEContext(DbContextOptions<JOBGATEContext> options)
            : base(options)
        {
        }
        public DbSet<IndustryCodeList> IndustryCodeList { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserAccount>().ToTable("User");
            builder.Entity<IdentityRole>().ToTable("Role");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }
    }
}
