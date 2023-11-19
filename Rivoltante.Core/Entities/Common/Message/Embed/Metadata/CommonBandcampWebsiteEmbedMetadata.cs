﻿namespace Rivoltante.Core;

public sealed class CommonBandcampWebsiteEmbedMetadata(MessageWebsiteEmbedSpecialApiModel model) : CommonWebsiteEmbedMetadata(model)
{
    public BandcampContentType ContentType { get; } = Enum.Parse<BandcampContentType>(model.ContentType.Value);

    public string Id { get; } = model.Id.Value;
}