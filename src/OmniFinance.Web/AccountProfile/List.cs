using FastEndpoints;
using MediatR;
using OmniFinance.UseCases.AccountProfiles.List;
using OmniFinance.Web.Endpoints.AccountProfileEndpoints;

namespace OmniFinance.Web.AccountProfileEndpoints;

/// <summary>
/// List all AccountProfiles
/// </summary>
/// <remarks>
/// List all AccountProfiles - returns a AccountProfileListResponse containing the AccountProfiles.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<AccountProfileListResponse>
{
  public override void Configure()
  {
    Get("/accountprofiles");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListAccountProfilesQuery(null, null));

    if (result.IsSuccess)
    {
      Response = new AccountProfileListResponse
      {
        AccountProfiles = result.Value.Select(c => new AccountProfileRecord(c.Id, c.Name, c.Status, c.Email)).ToList()
      };
    }
  }
}
