using System.Threading.Tasks;
using Ardalis.Result;

namespace OmniFinance.Core.Interfaces;

public interface IDeleteAccountProfileService
{
  // This service and method exist to provide a place in which to fire domain events
  // when deleting this aggregate root entity
  public Task<Result> DeleteAccountProfile(int AccountProfileId);
}
