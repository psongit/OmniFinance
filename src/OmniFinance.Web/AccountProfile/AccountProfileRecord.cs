using OmniFinance.Core.AccountProfileAggregate;
namespace OmniFinance.Web.AccountProfileEndpoints;

public record AccountProfileRecord(int Id, string Name, AccountProfileStatus Status, string Email);
