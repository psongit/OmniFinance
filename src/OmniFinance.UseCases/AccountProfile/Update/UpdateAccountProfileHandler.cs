using System.Threading;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;
using OmniFinance.Core.AccountProfileAggregate;

namespace OmniFinance.UseCases.AccountProfiles.Update;

public class UpdateAccountProfileHandler(IRepository<AccountProfile> _repository)
  : ICommandHandler<UpdateAccountProfileCommand, Result<AccountProfileDTO>>
{
  public async Task<Result<AccountProfileDTO>> Handle(UpdateAccountProfileCommand request, CancellationToken cancellationToken)
  {
    var existingAccountProfile = await _repository.GetByIdAsync(request.AccountProfileId, cancellationToken);
    if (existingAccountProfile == null)
    {
      return Result.NotFound();
    }

    existingAccountProfile.UpdateName(request.NewName!);

    await _repository.UpdateAsync(existingAccountProfile, cancellationToken);

    return Result.Success(new AccountProfileDTO { Id = existingAccountProfile.Id, Name = existingAccountProfile.Name, Status = existingAccountProfile.Status, Email = existingAccountProfile.Email });
  }
}
