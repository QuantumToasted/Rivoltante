using Rivoltante.Core;

namespace Rivoltante.Rest;

public sealed record RevoltMessageSearch(
    string Query,
    int? Limit = null,
    Ulid? BeforeMessageId = null,
    Ulid? AfterMessageId = null,
    MessageSortOrder? SortOrder = null,
    bool? IncludeUsers = null);