using OmniFinance.Core.AccountProfileAggregate;
namespace OmniFinance.UseCases.AccountProfiles;
public class AccountProfileDTO()
{
  public int Id { get; set; } = default!;
  public string Name { get; set; } = default!;
  public AccountProfileStatus Status { get; set; } = default!;
  public string Email { get; set; } = default!;

}
