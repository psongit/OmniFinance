using System.ComponentModel.DataAnnotations;

namespace OmniFinance.Web.Endpoints.AccountProfileEndpoints;

public class UpdateAccountProfileRequest
{
  public const string Route = "/AccountProfile/{AccountProfileId:int}";
  public static string BuildRoute(int AccountProfileId) => Route.Replace("{AccountProfileId:int}", AccountProfileId.ToString());

  public int AccountProfileId { get; set; }

  [Required]
  public int Id { get; set; }
  [Required]
  public string? Name { get; set; }
}
