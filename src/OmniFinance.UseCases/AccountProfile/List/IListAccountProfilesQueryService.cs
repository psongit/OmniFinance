using System.Collections.Generic;
using System.Threading.Tasks;

namespace OmniFinance.UseCases.AccountProfiles.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListAccountProfilesQueryService
{
  Task<IEnumerable<AccountProfileDTO>> ListAsync();
}
