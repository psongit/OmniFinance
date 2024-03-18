using OmniFinance.Web.AccountProfileEndpoints;

namespace OmniFinance.Web.Endpoints.AccountProfileEndpoints;

public class AccountProfileListResponse
{
  public List<AccountProfileRecord> AccountProfiles { get; set; } = [];
}
