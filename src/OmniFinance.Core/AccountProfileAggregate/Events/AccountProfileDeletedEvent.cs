using Ardalis.SharedKernel;

namespace OmniFinance.Core.AccountProfileAggregate.Events;

/// <summary>
/// A domain event that is dispatched whenever a AccountProfile is deleted.
/// The DeleteAccountProfileService is used to dispatch this event.
/// </summary>
internal sealed class AccountProfileDeletedEvent(int AccountProfileId) : DomainEventBase
{
  public int AccountProfileId { get; init; } = AccountProfileId;
}
