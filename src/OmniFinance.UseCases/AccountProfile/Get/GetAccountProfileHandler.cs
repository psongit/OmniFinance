using System.Threading;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;
using OmniFinance.Core.AccountProfileAggregate;
using OmniFinance.Core.AccountProfileAggregate.Specifications;

namespace OmniFinance.UseCases.AccountProfiles.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetAccountProfileHandler(IReadRepository<AccountProfile> _repository)
  : IQueryHandler<GetAccountProfileQuery, Result<AccountProfileDTO>>
{
  public async Task<Result<AccountProfileDTO>> Handle(GetAccountProfileQuery request, CancellationToken cancellationToken)
  {
    var spec = new AccountProfileByIdSpec(request.accountProfileId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    var accountProfile = new AccountProfileDTO { Id = entity.Id, Name = entity.Name, Status = entity.Status, Email = entity.Email };

    return accountProfile;
  }
}
