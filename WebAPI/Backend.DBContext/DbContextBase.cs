using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.DBContext
{
    public abstract class DbContextBase<TIdentityUser, TIdentityRole, TIdentityUserRole, TKey> : IdentityDbContext<TIdentityUser,
        TIdentityRole, TKey,
        IdentityUserClaim<TKey>,
        TIdentityUserRole,
        IdentityUserLogin<TKey>,
        IdentityRoleClaim<TKey>, IdentityUserToken<TKey>> 
        where TIdentityUser : IdentityUser<TKey> 
        where TIdentityRole : IdentityRole<TKey> 
        where TIdentityUserRole: IdentityUserRole<TKey> 
        where TKey: IEquatable<TKey>
    {
        protected DbContextBase(DbContextOptions options) : base(options){}
    }
}