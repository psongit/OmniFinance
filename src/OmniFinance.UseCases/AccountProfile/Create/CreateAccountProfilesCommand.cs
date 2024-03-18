using Ardalis.Result;
using OmniFinance.Core.AccountProfileAggregate;

namespace OmniFinance.UseCases.AccountProfiles.Create;

/// <summary>
/// Create a new OmniFinance.
/// </summary>
/// <param name="Name"></param>
public record CreateAccountProfileCommand(string Name, AccountProfileStatus Status, string Email) : Ardalis.SharedKernel.ICommand<Result<int>>;
