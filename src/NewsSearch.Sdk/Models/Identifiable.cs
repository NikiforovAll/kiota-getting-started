// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace NewsSearch.Sdk.Models {
    /// <summary>
    /// Defines the identity of a resource.
    /// </summary>
    public class Identifiable : ResponseBase, IParsable {
        /// <summary>A String identifier.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id { get; private set; }
#nullable restore
#else
        public string Id { get; private set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Identifiable"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Identifiable CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("_type")?.GetStringValue();
            return mappingValue switch {
                "Answer" => new Answer(),
                "Article" => new Article(),
                "CreativeWork" => new CreativeWork(),
                "ImageObject" => new ImageObject(),
                "MediaObject" => new MediaObject(),
                "NewsArticle" => new NewsArticle(),
                "NewsTopic" => new NewsTopic(),
                "Organization" => new Organization(),
                "Response" => new Response(),
                "Thing" => new Thing(),
                "TrendingTopics" => new TrendingTopics(),
                "VideoObject" => new VideoObject(),
                _ => new Identifiable(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"id", n => { Id = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
        }
    }
}
