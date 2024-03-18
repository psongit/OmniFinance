using Ardalis.Specification;

namespace OmniFinance.Core.AccountProfileAggregate.Specifications;

public class AccountProfileByIdSpec : Specification<AccountProfile>
{
  public AccountProfileByIdSpec(int AccountProfileId)
  {
    Query
        .Where(AccountProfile => AccountProfile.Id == AccountProfileId);
  }
}
