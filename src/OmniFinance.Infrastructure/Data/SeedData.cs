using OmniFinance.Core.AccountProfileAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace OmniFinance.Infrastructure.Data;

public static class SeedData
{
  public static readonly AccountProfile AccountProfile1 = new("Red Sun Enterprises", AccountProfileStatus.Active, "Organization 01");
  public static readonly AccountProfile AccountProfile2 = new("Green Sun Enterprises", AccountProfileStatus.Active, "Organization 02");
  public static readonly AccountProfile AccountProfile3 = new("Blue Sun Enterprises", AccountProfileStatus.Active, "Organization 03");
  public static readonly AccountProfile AccountProfile4 = new("Yellow Sun Enterprises", AccountProfileStatus.Active, "Organization 04");
  public static readonly AccountProfile AccountProfile5 = new("Pink Sun Enterprises", AccountProfileStatus.Active, "Organization 05");
  public static readonly AccountProfile AccountProfile6 = new("Amber Sun Enterprises", AccountProfileStatus.Active, "Organization 06");
  public static readonly AccountProfile AccountProfile7 = new("Green Sun Enterprises", AccountProfileStatus.Active, "Organization 07");
  public static readonly AccountProfile AccountProfile8 = new("White Sun Enterprises", AccountProfileStatus.Active, "Organization 08");

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      // Look for any AccountProfiles.
      if (dbContext.AccountProfiles.Any())
      {
        return;   // DB has been seeded
      }


      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.AccountProfiles)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    dbContext.AccountProfiles.Add(AccountProfile1);
    dbContext.AccountProfiles.Add(AccountProfile2);
    dbContext.AccountProfiles.Add(AccountProfile3);
    dbContext.AccountProfiles.Add(AccountProfile4);
    dbContext.AccountProfiles.Add(AccountProfile5);
    dbContext.AccountProfiles.Add(AccountProfile6);
    dbContext.AccountProfiles.Add(AccountProfile7);
    dbContext.AccountProfiles.Add(AccountProfile8);

    dbContext.SaveChanges();
  }
}
