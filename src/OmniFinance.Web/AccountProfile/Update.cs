using FastEndpoints;
using OmniFinance.UseCases.AccountProfiles.Update;
using MediatR;
using Ardalis.Result;
using OmniFinance.UseCases.AccountProfiles.Get;
using OmniFinance.Web.Endpoints.AccountProfileEndpoints;

namespace OmniFinance.Web.AccountProfileEndpoints;

/// <summary>
/// Update an existing AccountProfile.
/// </summary>
/// <remarks>
/// Update an existing AccountProfile by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdateAccountProfileRequest, UpdateAccountProfileResponse>
{
  public override void Configure()
  {
    Put(UpdateAccountProfileRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateAccountProfileRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateAccountProfileCommand(request.Id, request.Name!));

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetAccountProfileQuery(request.AccountProfileId);

    var queryResult = await _mediator.Send(query);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateAccountProfileResponse(new AccountProfileRecord(dto.Id, dto.Name, dto.Status, dto.Email));
      return;
    }
  }
}
