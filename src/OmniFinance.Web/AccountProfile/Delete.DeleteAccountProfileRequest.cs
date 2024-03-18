namespace OmniFinance.Web.Endpoints.AccountProfileEndpoints;

public record DeleteAccountProfileRequest
{
  public const string Route = "/OmniFinances/{AccountProfileId:int}";
  public static string BuildRoute(int AccountProfileId) => Route.Replace("{AccountProfileId:int}", AccountProfileId.ToString());

  public int AccountProfileId { get; set; }
}
