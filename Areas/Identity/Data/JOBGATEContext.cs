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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserAccount>().ToTable("ACC_User");
            builder.Entity<IdentityRole>().ToTable("ACC_Role");
            builder.Entity<IdentityUserRole<string>>().ToTable("ACC_UserRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("ACC_UserClaim");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("ACC_RoleClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("ACC_UserLogin");
            builder.Entity<IdentityUserToken<string>>().ToTable("ACC_UserTokens");
           
        }
    }
}
