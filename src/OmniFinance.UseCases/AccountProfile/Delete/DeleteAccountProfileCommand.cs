using Ardalis.Result;
using Ardalis.SharedKernel;

namespace OmniFinance.UseCases.AccountProfiles.Delete;

public record DeleteAccountProfileCommand(int AccountProfileId) : ICommand<Result>;
