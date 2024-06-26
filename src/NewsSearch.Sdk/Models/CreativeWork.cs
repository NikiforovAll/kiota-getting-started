// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace NewsSearch.Sdk.Models {
    /// <summary>
    /// The most generic kind of creative work, including books, movies, photographs, software programs, etc.
    /// </summary>
    public class CreativeWork : Thing, IParsable {
        /// <summary>The date on which the CreativeWork was published.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DatePublished { get; private set; }
#nullable restore
#else
        public string DatePublished { get; private set; }
#endif
        /// <summary>The source of the creative work.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Thing>? Provider { get; private set; }
#nullable restore
#else
        public List<Thing> Provider { get; private set; }
#endif
        /// <summary>The URL to a thumbnail of the item.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ThumbnailUrl { get; private set; }
#nullable restore
#else
        public string ThumbnailUrl { get; private set; }
#endif
        /// <summary>Defines a video object that is relevant to the query.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public VideoObject? Video { get; set; }
#nullable restore
#else
        public VideoObject Video { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="CreativeWork"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new CreativeWork CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("_type")?.GetStringValue();
            return mappingValue switch {
                "Article" => new Article(),
                "ImageObject" => new ImageObject(),
                "MediaObject" => new MediaObject(),
                "NewsArticle" => new NewsArticle(),
                "VideoObject" => new VideoObject(),
                _ => new CreativeWork(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"datePublished", n => { DatePublished = n.GetStringValue(); } },
                {"provider", n => { Provider = n.GetCollectionOfObjectValues<Thing>(Thing.CreateFromDiscriminatorValue)?.ToList(); } },
                {"thumbnailUrl", n => { ThumbnailUrl = n.GetStringValue(); } },
                {"video", n => { Video = n.GetObjectValue<VideoObject>(VideoObject.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<VideoObject>("video", Video);
        }
    }
}
