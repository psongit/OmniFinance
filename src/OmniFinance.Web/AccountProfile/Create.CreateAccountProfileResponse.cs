namespace OmniFinance.Web.Endpoints.AccountProfileEndpoints;

public class CreateAccountProfileResponse(int id, string name)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
}
