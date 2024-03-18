
using OmniFinance.Web.AccountProfileEndpoints;

namespace OmniFinance.Web.Endpoints.AccountProfileEndpoints;

public class UpdateAccountProfileResponse(AccountProfileRecord accountProfile)
{
  public AccountProfileRecord AccountProfile { get; set; } = accountProfile;
}
