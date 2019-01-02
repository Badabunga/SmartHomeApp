using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Hue.BusinessLogic.Extensions
{
    public class LowerCaseSerializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new LowerCaseContractResolver()
        };

        private static readonly JsonSerializerSettings SettingsWithoutNullProperties = new JsonSerializerSettings
        {
            ContractResolver = new LowerCaseContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public static string SerializeObject(object o) =>
            JsonConvert.SerializeObject(o, Formatting.None, Settings);

        public static string SerializeObjectWithoutNullProperties(object o) =>
            JsonConvert.SerializeObject(o, Formatting.None, SettingsWithoutNullProperties);

    }

    public class LowerCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
