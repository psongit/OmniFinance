using FastEndpoints;
using MediatR;
using Ardalis.Result;
using OmniFinance.Web.Endpoints.AccountProfileEndpoints;
using OmniFinance.UseCases.AccountProfiles.Get;

namespace OmniFinance.Web.AccountProfileEndpoints;

/// <summary>
/// Get a AccountProfile by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching AccountProfile record.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetAccountProfileByIdRequest, AccountProfileRecord>
{
  public override void Configure()
  {
    Get(GetAccountProfileByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetAccountProfileByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetAccountProfileQuery(request.AccountProfileId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new AccountProfileRecord(result.Value.Id, result.Value.Name, result.Value.Status, result.Value.Email);
    }
  }
}
