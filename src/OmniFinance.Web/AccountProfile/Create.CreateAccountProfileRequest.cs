using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OmniFinance.Core.AccountProfileAggregate;
using OmniFinance.Infrastructure.Convertors;

namespace OmniFinance.Web.Endpoints.AccountProfileEndpoints;
public class CreateAccountProfileRequest
{
  public const string Route = "/accountprofile";

  [Required]
  public string? Name { get; set; }

  [Required]
  [JsonConverter(typeof(AccountProfileStatusNameConverter))]
  public AccountProfileStatus? Status { get; set; }

  [Required]
  public string? Email { get; set; }

}
