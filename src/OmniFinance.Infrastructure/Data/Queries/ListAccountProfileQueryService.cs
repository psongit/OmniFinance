using Microsoft.EntityFrameworkCore;
using OmniFinance.UseCases.AccountProfiles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmniFinance.Infrastructure.Data.Queries;

public class ListAccountProfileQueryService(AppDbContext _db) : IListAccountProfilesQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries - this is just an example

  public async Task<IEnumerable<AccountProfileDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider
    var result = await _db.AccountProfiles.FromSqlRaw("SELECT Id, Name, Status, Email FROM AccountProfiles") // don't fetch other big columns
      .Select(c => new AccountProfileDTO { Id = c.Id, Name = c.Name, Status = c.Status, Email = c.Email })
      .ToListAsync();

    return result;
  }
}
