//  Copyright © 2009-2020 John Sheehan, Andrew Young, Alexey Zimarev and RestSharp community
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Text.Json;
using RestSharp.Serialization;

namespace RestSharp.Serializers.SystemTextJson {
    public class SystemTextJsonSerializer : IRestSerializer {
        readonly JsonSerializerOptions _options;

        /// <summary>
        /// Create the new serializer that uses System.Text.Json.JsonSerializer with default settings
        /// </summary>
        public SystemTextJsonSerializer() => _options = new JsonSerializerOptions();

        /// <summary>
        /// Create the new serializer that uses System.Text.Json.JsonSerializer with custom settings
        /// </summary>
        /// <param name="options">Json serializer settings</param>
        public SystemTextJsonSerializer(JsonSerializerOptions options) => _options = options;

        public string Serialize(object obj) => JsonSerializer.Serialize(obj, _options);

        public string Serialize(Parameter bodyParameter) => Serialize(bodyParameter.Value);

        public T Deserialize<T>(IRestResponse response) => JsonSerializer.Deserialize<T>(response.Content, _options);

        public string[] SupportedContentTypes { get; } = {
            "application/json", "text/json", "text/x-json", "text/javascript", "*+json"
        };

        public string ContentType { get; set; } = "application/json";

        public DataFormat DataFormat { get; } = DataFormat.Json;
    }
}
