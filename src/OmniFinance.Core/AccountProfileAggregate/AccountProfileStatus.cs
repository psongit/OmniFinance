using Ardalis.SmartEnum;

namespace OmniFinance.Core.AccountProfileAggregate;

public sealed class AccountProfileStatus : SmartEnum<AccountProfileStatus>
{
  public static readonly AccountProfileStatus Active = new(nameof(Active), 1);
  public static readonly AccountProfileStatus Disabled = new(nameof(Disabled), 2);

  public AccountProfileStatus(string name, int value) : base(name, value) { }
}
