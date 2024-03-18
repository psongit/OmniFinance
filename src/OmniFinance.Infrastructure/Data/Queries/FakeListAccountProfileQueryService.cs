using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OmniFinance.Core.AccountProfileAggregate;
using OmniFinance.UseCases.AccountProfiles;

namespace OmniFinance.Infrastructure.Data.Queries;

public class FakeListAccountProfileQueryService : IListAccountProfilesQueryService
{
  public Task<IEnumerable<AccountProfileDTO>> ListAsync()
  {
    List<AccountProfileDTO> result =
        [new AccountProfileDTO{ Id= 1, Name= "Fake AccountProfile 1", Status= AccountProfileStatus.Active, Email= "AccountProfile Description 01" },
          new AccountProfileDTO{ Id= 1, Name= "Fake AccountProfile 1", Status= AccountProfileStatus.Active, Email= "AccountProfile Description 01" }];

    return Task.FromResult(result.AsEnumerable());
  }
}
