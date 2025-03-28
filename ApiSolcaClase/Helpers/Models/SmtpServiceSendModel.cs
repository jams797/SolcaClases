namespace ApiSolcaClase.Helpers.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SmtpServiceSendModel
    {
        [JsonProperty("To")]
        public string[] To { get; set; }

        [JsonProperty("Subject")]
        public string Subject { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }

    public partial class SmtpServiceSendModel
    {
        public static SmtpServiceSendModel FromJson(string json) => JsonConvert.DeserializeObject<SmtpServiceSendModel>(json, ApiSolcaClase.Helpers.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SmtpServiceSendModel self) => JsonConvert.SerializeObject(self, ApiSolcaClase.Helpers.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
