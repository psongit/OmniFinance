using Ardalis.Result;
using Ardalis.SharedKernel;

namespace OmniFinance.UseCases.AccountProfiles.Get;

public record GetAccountProfileQuery(int accountProfileId) : IQuery<Result<AccountProfileDTO>>;
