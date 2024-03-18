using System.Threading;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;
using OmniFinance.Core.Interfaces;

namespace OmniFinance.UseCases.AccountProfiles.Delete;

public class DeleteAccountProfileHandler(IDeleteAccountProfileService _deleteAccountProfileService)
  : ICommandHandler<DeleteAccountProfileCommand, Result>
{
  public async Task<Result> Handle(DeleteAccountProfileCommand request, CancellationToken cancellationToken)
  {
    // This Approach: Keep Domain Events in the Domain Model / Core project; this becomes a pass-through
    // This is @ardalis's preferred approach
    return await _deleteAccountProfileService.DeleteAccountProfile(request.AccountProfileId);

    // Another Approach: Do the real work here including dispatching domain events - change the event from internal to public
    // @ardalis prefers using the service above so that **domain** event behavior remains in the **domain model** (core project)
    // var aggregateToDelete = await _repository.GetByIdAsync(request.AccountProfileId);
    // if (aggregateToDelete == null) return Result.NotFound();

    // await _repository.DeleteAsync(aggregateToDelete);
    // var domainEvent = new AccountProfileDeletedEvent(request.AccountProfileId);
    // await _mediator.Publish(domainEvent);
    // return Result.Success();
  }
}
