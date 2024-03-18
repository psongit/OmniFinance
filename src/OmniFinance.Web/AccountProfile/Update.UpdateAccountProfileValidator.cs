using OmniFinance.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace OmniFinance.Web.Endpoints.AccountProfileEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class UpdateAccountProfileValidator : Validator<UpdateAccountProfileRequest>
{
  public UpdateAccountProfileValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.AccountProfileId)
      .Must((args, AccountProfileId) => args.Id == AccountProfileId)
      .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
  }
}
