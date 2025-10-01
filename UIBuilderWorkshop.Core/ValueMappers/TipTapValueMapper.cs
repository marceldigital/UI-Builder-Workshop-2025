using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Serialization;
using Umbraco.UIBuilder.Mapping;

namespace UIBuilderWorkshop.Core.ValueMappers;

/// <summary>
/// Maps values between the TipTap rich text editor and the string model representation.
/// </summary>
internal class TipTapValueMapper : ValueMapper
{
    private readonly IJsonSerializer _jsonSerializer;
    private readonly ILogger<TipTapValueMapper> _logger;

    public TipTapValueMapper(IJsonSerializer jsonSerializer, ILogger<TipTapValueMapper> logger)
    {
        _jsonSerializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Converts the editor value to the model value.
    /// </summary>
    /// <param name="input">The value from the editor.</param>
    /// <returns>
    /// The markup string if parsing is successful; otherwise, <c>null</c>.
    /// </returns>
    public override object? EditorToModel(object? input)
        => RichTextPropertyEditorHelper.TryParseRichTextEditorValue(input, _jsonSerializer, _logger, out var richTextEditorValue)
            ? richTextEditorValue.Markup
            : null;

    /// <summary>
    /// Converts the model value to the editor value.
    /// </summary>
    /// <param name="input">The model value, expected to be a markup string.</param>
    /// <returns>
    /// The serialized <see cref="RichTextEditorValue"/> if input is a string; otherwise, <c>null</c>.
    /// </returns>
    public override object? ModelToEditor(object? input)
    {
        if (input is not string markup) return null;

        var richTextEditorvalue = new RichTextEditorValue
        {
            Markup = markup,
            Blocks = new RichTextBlockValue(),
        };

        return RichTextPropertyEditorHelper.SerializeRichTextEditorValue(richTextEditorvalue,_jsonSerializer);
    }
}
