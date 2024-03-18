using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;

namespace OmniFinance.UseCases.AccountProfiles.List;

public class ListAccountProfilesHandler(IListAccountProfilesQueryService _query)
  : IQueryHandler<ListAccountProfilesQuery, Result<IEnumerable<AccountProfileDTO>>>
{
  public async Task<Result<IEnumerable<AccountProfileDTO>>> Handle(ListAccountProfilesQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
