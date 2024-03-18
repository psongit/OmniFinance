using FastEndpoints;
using MediatR;
using OmniFinance.Core.AccountProfileAggregate;
using OmniFinance.UseCases.AccountProfiles.Create;
using OmniFinance.Web.Endpoints.AccountProfileEndpoints;

namespace OmniFinance.Web.AccountProfileEndpoints;

/// <summary>
/// Create a new AccountProfile
/// </summary>
/// <remarks>
/// Creates a new AccountProfile given a name.
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreateAccountProfileRequest, CreateAccountProfileResponse>
{
  public override void Configure()
  {
    Post(CreateAccountProfileRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new AccountProfile.";
      //s.Description = "Create a new AccountProfile. A valid name is required.";
      s.ExampleRequest = new CreateAccountProfileRequest { Name = "AccountProfile Name", Status= AccountProfileStatus.Active, Email= "AccountProfile Description 01" };
    });
  }

  public override async Task HandleAsync(
    CreateAccountProfileRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateAccountProfileCommand(request.Name!, request.Status!, request.Email!));

    if(result.IsSuccess)
    {
      Response = new CreateAccountProfileResponse(result.Value, request.Name!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
