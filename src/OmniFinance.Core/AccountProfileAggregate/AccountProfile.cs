using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace OmniFinance.Core.AccountProfileAggregate;

public class AccountProfile(string name, AccountProfileStatus status, string email) : EntityBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));

  public AccountProfileStatus Status { get; private set; } = status;
  
  public string Email { get; private set; } = email;

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
