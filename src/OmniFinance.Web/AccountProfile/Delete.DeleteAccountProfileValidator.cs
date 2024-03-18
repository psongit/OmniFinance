using FastEndpoints;
using FluentValidation;

namespace OmniFinance.Web.Endpoints.AccountProfileEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class DeleteAccountProfileValidator : Validator<DeleteAccountProfileRequest>
{
  public DeleteAccountProfileValidator()
  {
    RuleFor(x => x.AccountProfileId)
      .GreaterThan(0);
  }
}
