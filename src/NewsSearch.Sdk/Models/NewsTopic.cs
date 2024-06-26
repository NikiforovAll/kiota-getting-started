// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace NewsSearch.Sdk.Models {
    public class NewsTopic : Thing, IParsable {
        /// <summary>A Boolean value that indicates whether the topic is considered breaking news. If the topic is considered breaking news, the value is true.</summary>
        public bool? IsBreakingNews { get; private set; }
        /// <summary>The URL to the Bing News search results for the search query term</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? NewsSearchUrl { get; private set; }
#nullable restore
#else
        public string NewsSearchUrl { get; private set; }
#endif
        /// <summary>Defines a search query.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NewsSearch.Sdk.Models.Query? Query { get; set; }
#nullable restore
#else
        public NewsSearch.Sdk.Models.Query Query { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="NewsTopic"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new NewsTopic CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new NewsTopic();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"isBreakingNews", n => { IsBreakingNews = n.GetBoolValue(); } },
                {"newsSearchUrl", n => { NewsSearchUrl = n.GetStringValue(); } },
                {"query", n => { Query = n.GetObjectValue<NewsSearch.Sdk.Models.Query>(NewsSearch.Sdk.Models.Query.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<NewsSearch.Sdk.Models.Query>("query", Query);
        }
    }
}
