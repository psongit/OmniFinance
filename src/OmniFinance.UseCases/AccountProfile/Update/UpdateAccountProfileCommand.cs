using Ardalis.Result;
using Ardalis.SharedKernel;

namespace OmniFinance.UseCases.AccountProfiles.Update;

public record UpdateAccountProfileCommand(int AccountProfileId, string NewName) : ICommand<Result<AccountProfileDTO>>;
