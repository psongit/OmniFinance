namespace OmniFinance.Web.Endpoints.AccountProfileEndpoints;

public class GetAccountProfileByIdRequest
{
  public const string Route = "/AccountProfiles/{AccountProfile:int}";
  public static string BuildRoute(int AccountProfileId) => Route.Replace("{AccountProfileId:int}", AccountProfileId.ToString());

  public int AccountProfileId { get; set; }
}
