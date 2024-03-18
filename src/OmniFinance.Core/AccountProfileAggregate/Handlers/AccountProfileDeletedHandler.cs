using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using OmniFinance.Core.AccountProfileAggregate.Events;

namespace OmniFinance.Core.AccountProfileAggregate.Handlers;

/// <summary>
/// NOTE: Internal because AccountProfileDeleted is also marked as internal.
/// </summary>
internal class AccountProfileDeletedHandler(ILogger<AccountProfileDeletedHandler> _logger) : INotificationHandler<AccountProfileDeletedEvent>
{
  public async Task Handle(AccountProfileDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Handling Contributed Deleted event for {AccountProfileId}", domainEvent.AccountProfileId);

    // TODO: do meaningful work here
    await Task.Delay(1);
  }
}
