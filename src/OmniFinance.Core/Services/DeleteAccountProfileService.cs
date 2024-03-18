using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;
using MediatR;
using Microsoft.Extensions.Logging;
using OmniFinance.Core.AccountProfileAggregate;
using OmniFinance.Core.AccountProfileAggregate.Events;
using OmniFinance.Core.Interfaces;

namespace OmniFinance.Core.Services;

public class DeleteAccountProfileService(IRepository<AccountProfile> _repository,
  IMediator _mediator,
  ILogger<DeleteAccountProfileService> _logger) : IDeleteAccountProfileService
{
  public async Task<Result> DeleteAccountProfile(int AccountProfileId)
  {
    _logger.LogInformation("Deleting AccountProfile {AccountProfileId}", AccountProfileId);
    var aggregateToDelete = await _repository.GetByIdAsync(AccountProfileId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new AccountProfileDeletedEvent(AccountProfileId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
