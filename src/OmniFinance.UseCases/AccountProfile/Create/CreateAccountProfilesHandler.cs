using System.Threading;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;
using OmniFinance.Core.AccountProfileAggregate;

namespace OmniFinance.UseCases.AccountProfiles.Create;

public class CreateAccountProfilesHandler(IRepository<AccountProfile> _repository)
  : ICommandHandler<CreateAccountProfileCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateAccountProfileCommand request,
    CancellationToken cancellationToken)
  {
    var newAccountProfile = new AccountProfile(request.Name, request.Status, request.Email);
    var createdItem = await _repository.AddAsync(newAccountProfile, cancellationToken);

    return createdItem.Id;
  }
}
