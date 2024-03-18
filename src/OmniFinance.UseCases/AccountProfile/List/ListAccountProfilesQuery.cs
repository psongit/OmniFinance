using System.Collections.Generic;
using Ardalis.Result;
using Ardalis.SharedKernel;

namespace OmniFinance.UseCases.AccountProfiles.List;

public record ListAccountProfilesQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<AccountProfileDTO>>>;
