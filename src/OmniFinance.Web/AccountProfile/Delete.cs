using FastEndpoints;
using Ardalis.Result;
using MediatR;
using OmniFinance.Web.Endpoints.AccountProfileEndpoints;
using OmniFinance.UseCases.AccountProfiles.Delete;

namespace OmniFinance.Web.OmniFinanceEndpoints;

/// <summary>
/// Delete a AccountProfile.
/// </summary>
/// <remarks>
/// Delete a AccountProfile by providing a valid integer id.
/// </remarks>
public class Delete(IMediator _mediator)
  : Endpoint<DeleteAccountProfileRequest>
{
  public override void Configure()
  {
    Delete(DeleteAccountProfileRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteAccountProfileRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteAccountProfileCommand(request.AccountProfileId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    };
    // TODO: Handle other issues as needed
  }
}
