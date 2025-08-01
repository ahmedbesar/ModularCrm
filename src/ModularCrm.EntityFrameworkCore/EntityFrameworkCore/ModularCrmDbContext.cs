using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using ModularCrm.Products.EntityFrameworkCore;
using ModularCrm.Products.Products;
using ModularCrm.Ordering.EntityFrameworkCore;
using ModularCrm.Ordering.Orders;
using Volo.Abp.EntityFrameworkCore.DistributedEvents;

namespace ModularCrm.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
[ReplaceDbContext(typeof(IProductsDbContext))]
[ReplaceDbContext(typeof(IOrderingDbContext))]

public class ModularCrmDbContext :
    AbpDbContext<ModularCrmDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext,
    IHasEventOutbox, IHasEventInbox,
    IProductsDbContext,IOrderingDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    public DbSet<Product> Products { get ; set ; }
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OutgoingEventRecord> OutgoingEvents { get; set; }
    public DbSet<IncomingEventRecord> IncomingEvents { get; set; }
    
    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public ModularCrmDbContext(DbContextOptions<ModularCrmDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureEventOutbox();
        builder.ConfigureEventInbox();
        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(ModularCrmConsts.DbTablePrefix + "YourEntities", ModularCrmConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.ConfigureProducts();
            builder.ConfigureOrdering();
        }
}
