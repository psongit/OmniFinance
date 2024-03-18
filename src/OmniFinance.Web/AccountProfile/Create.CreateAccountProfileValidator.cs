using OmniFinance.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace OmniFinance.Web.Endpoints.AccountProfileEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class CreateAccountProfileValidator : Validator<CreateAccountProfileRequest>
{
  public CreateAccountProfileValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
  }
}
