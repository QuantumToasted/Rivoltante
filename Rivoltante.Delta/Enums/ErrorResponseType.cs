﻿namespace Rivoltante.Delta;

public enum ErrorResponseType
{
    LabelMe,
    Core,
    AlreadyOnboarded,
    UsernameTaken,
    InvalidUsername,
    UnknownUser,
    AlreadyFriends,
    AlreadySentRequest,
    Blocked,
    BlockedByOther,
    NotFriends,
    UnknownChannel,
    UnknownAttachment,
    UnknownMessage,
    CannotEditMessage,
    CannotJoinCall,
    TooManyAttachments,
    TooManyReplies,
    TooManyChannels,
    TooManyEmbeds,
    EmptyMessage,
    PayloadTooLarge,
    CannotRemoveYourself,
    GroupTooLarge,
    AlreadyInGroup,
    NotInGroup,
    UnknownServer,
    InvalidRole,
    Banned,
    TooManyServers,
    TooManyEmoji,
    TooManyRoles,
    ReachedMaximumBots,
    IsBot,
    BotIsPrivate,
    CannotReportYourself,
    MissingPermission,
    MissingUserPermission,
    NotElevated,
    NotPrivileged,
    CannotGiveMissingPermissions,
    NotOwner,
    DatabaseError,
    InternalError,
    InvalidOperation,
    InvalidCredentials,
    InvalidProperty,
    InvalidSession,
    DuplicateNonce,
    VosoUnavailable,
    NotFound,
    NoEffect,
    FailedValidation
}