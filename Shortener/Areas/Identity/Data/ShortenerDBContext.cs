using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shortener.Areas.Identity.Data;
using Shortener.Models;

namespace Shortener.Data;

public class ShortenerDBContext : IdentityDbContext<ShortenerUser, ShortenerRole, string>
{
    public ShortenerDBContext(DbContextOptions<ShortenerDBContext> options)
        : base(options)
    {
    }

    public DbSet<UrlModel> Urls { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);


        //builder.ApplyConfiguration(new ShortenerUserEntityConfiguration());

 
    }
}
