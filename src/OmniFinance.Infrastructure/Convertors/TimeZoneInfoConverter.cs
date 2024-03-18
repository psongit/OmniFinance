
//using System.Runtime.Serialization;
//using System.Text.Json;
//using System.Text.Json.Serialization;

//namespace OmniFinance.Infrastructure.Convertors;
//public class TimeZoneInfoConverter : JsonConverter<TimeZoneInfo>
//{
//  public override TimeZoneInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//  {
//    var value = reader.GetString() ?? string.Empty;
//    if (reader.TokenType == JsonTokenType.String && !string.IsNullOrEmpty(value))
//    {
//      return GetFromTimeZoneString(value);
//    }

//    static TimeZoneInfo? GetFromTimeZoneString(string value)
//    {
//      TimeZoneInfo? timeZoneInfo;
//      if (!TimeZoneInfo.TryFindSystemTimeZoneById(value, out timeZoneInfo))
//        timeZoneInfo = TimeZoneInfo.Utc;
//      return timeZoneInfo;
//    }

//    throw new SerializationException($"Unexpected token {reader.TokenType} when parsing a time zone");
//  }


//  public override void Write(Utf8JsonWriter writer, TimeZoneInfo value, JsonSerializerOptions options)
//  {
//    if (value == null)
//    {
//      writer.WriteNullValue();
//    }
//    else
//    {
//      writer.WriteStringValue(value.Id);
//    }
//  }
//}
