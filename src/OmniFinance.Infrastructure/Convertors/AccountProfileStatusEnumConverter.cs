using System;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using OmniFinance.Core.AccountProfileAggregate;

namespace OmniFinance.Infrastructure.Convertors;
public class AccountProfileStatusNameConverter : JsonConverter<AccountProfileStatus>
{
  public override AccountProfileStatus? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var value = reader.GetString() ?? string.Empty;
    if (reader.TokenType == JsonTokenType.String && !string.IsNullOrEmpty(value))
    {
      return GetFromAccountProfileStatusString(value);
    }

    static AccountProfileStatus? GetFromAccountProfileStatusString(string value)
    {
      AccountProfileStatus? AccountProfileStatus;
      if (!AccountProfileStatus.TryFromName(value, out AccountProfileStatus))
        AccountProfileStatus = AccountProfileStatus.Disabled;
      return AccountProfileStatus;
    }

    throw new SerializationException($"Unexpected token {reader.TokenType} when parsing a time zone");
  }

  public override void Write(Utf8JsonWriter writer, AccountProfileStatus value, JsonSerializerOptions options)
  {
    if (value == null)
    {
      writer.WriteNullValue();
    }
    else
    {
      writer.WriteStringValue(value.Name);
    }
  }
}
