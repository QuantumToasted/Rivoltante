namespace Rivoltante.Core;

[Flags]
public enum Permission : ulong // TODO: document permissions
{
    /// <summary>
    /// Allows creating, editing, and deleting channels.
    /// </summary>
    ManageChannels = 1ul << 0,
    
    /// <summary>
    /// Allows changing a server's name, description, icon, and other related information.
    /// </summary>
    ManageServer = 1ul << 1,
    
    /// <summary>
    /// Allows changing channel and server role permissions for roles with a lower ranking.
    /// </summary>
    ManagePermissions = 1ul << 2,
    
    /// <summary>
    /// Allows creating, editing, and deleting roles with a lower ranking. Implicitly grants <see cref="ManagePermissions"/>.
    /// </summary>
    ManageRoles = 1ul << 3,
    
    /// <summary>
    /// Allows creating, editing, and deleting emojis.
    /// </summary>
    ManageCustomisation = 1ul << 4,
    
    // 1ul << 5 unused
    
    /// <summary>
    /// Allows removing members from a server (kicking).
    /// </summary>
    KickMembers = 1ul << 6,
    
    /// <summary>
    /// Allows removing members from a server permanently (banning).
    /// </summary>
    BanMembers = 1ul << 7,
    
    /// <summary>
    /// Allows timing out of members in a server (temporarily preventing interaction).
    /// </summary>
    TimeoutMembers = 1ul << 8,
    
    /// <summary>
    /// Allows assigning roles with a lower ranking to other members.
    /// </summary>
    AssignRoles = 1ul << 9,
    
    /// <summary>
    /// Allows a member to change their own nickname.
    /// </summary>
    ChangeNickname = 1ul << 10,
    
    /// <summary>
    /// Allows changing or removing the nicknames of other members.
    /// </summary>
    ManageNicknames = 1ul << 11,
    
    /// <summary>
    /// Allows a member to change their own server avatar.
    /// </summary>
    ChangeAvatar = 1ul << 12,
    
    /// <summary>
    /// Allows removing the server avatars of other members.
    /// </summary>
    RemoveAvatars = 1ul << 13,
    
    // 1ul << 14 unused
    // 1ul << 15 unused
    // 1ul << 16 unused
    // 1ul << 17 unused
    // 1ul << 18 unused
    // 1ul << 19 unused
    
    /// <summary>
    /// Allows viewing channels which also have the <see cref="ViewChannel"/> permission set on them.
    /// </summary>
    ViewChannel = 1ul << 20,

    /// <summary>
    /// Allows viewing the message history of a channel.
    /// </summary>
    ReadMessageHistory = 1ul << 21, // TODO: cannot find a documented usage of this permission in the client
    
    /// <summary>
    /// Allows sending messages in text channels.
    /// </summary>
    SendMessage = 1ul << 22,
    
    /// <summary>
    /// Allows deleting of messages sent by other members.
    /// </summary>
    ManageMessages = 1ul << 23,
    
    /// <summary>
    /// Allows creating, editing and deleting of channel webhooks.
    /// </summary>
    ManageWebhooks = 1ul << 24, // TODO: cannot find a documented usage of this permission in the client
    
    /// <summary>
    /// Allows creating invites to a channel.
    /// </summary>
    InviteOthers = 1ul << 25,
    
    /// <summary>
    /// Allows embedded content in messages sent by a member (such as <see cref="EmbedType.Website"/> or <see cref="EmbedType.Text"/> embeds).
    /// </summary>
    SendEmbeds = 1ul << 26,
    
    /// <summary>
    /// Allows files to be attached to messages sent by a member.
    /// </summary>
    UploadFiles = 1ul << 27,
    
    /// <summary>
    /// Allows a member to change their name and avatar per-message.
    /// </summary>
    Masquerade = 1ul << 28,
    
    /// <summary>
    /// Allows adding reactions to messages.
    /// </summary>
    UseReactions = 1ul << 29,
    
    /// <summary>
    /// Allows connecting to a voice channel (also requires the <see cref="ViewChannel"/> permission on that channel).
    /// </summary>
    Connect = 1ul << 30,
    
    /// <summary>
    /// Allows speaking in a voice channel while connected.
    /// </summary>
    Speak = 1ul << 31,
    
    /// <summary>
    /// Allows the ability to stream video in a voice channel while connected.
    /// </summary>
    Video = 1ul << 32,
    
    /// <summary>
    /// Allows muting a user in a voice channel.
    /// </summary>
    MuteMembers = 1ul << 33,
    
    /// <summary>
    /// Allows deafening a user in a voice channel (making them unable to hear others).
    /// </summary>
    DeafenMembers = 1ul << 34,
    
    /// <summary>
    /// Allows moving a user to or from one voice channel to another.
    /// </summary>
    MoveMembers = 1ul << 35,
    
    // 1ul << 36 unused
    // 1ul << 37 unused
    // 1ul << 38 unused
    // 1ul << 39 unused
    // 1ul << 40 unused
    // 1ul << 41 unused
    // 1ul << 42 unused
    // 1ul << 43 unused
    // 1ul << 44 unused
    // 1ul << 45 unused
    // 1ul << 46 unused
    // 1ul << 47 unused
    // 1ul << 48 unused
    // 1ul << 49 unused
    // 1ul << 50 unused
    // 1ul << 51 unused
    // 1ul << 52 unused
    // 1ul << 53 unused
    // 1ul << 54 unused
    // 1ul << 55 unused
    // 1ul << 56 unused
    // 1ul << 57 unused
    // 1ul << 58 unused
    // 1ul << 59 unused
    // 1ul << 60 unused
    // 1ul << 61 unused
    // 1ul << 62 unused
    // 1ul << 63 unused
    
    /// <summary>
    /// Represents all possible permissions.
    /// </summary>
    GrantAll = ulong.MaxValue,
    
    /// <summary>
    /// Represents all currently defined permissions, instead of all possible permissions.
    /// </summary>
    GrantAllSafe = ManageChannels | ManageServer | ManagePermissions | ManageRoles |
              ManageCustomisation | KickMembers | BanMembers | TimeoutMembers |
              AssignRoles | ChangeNickname | ManageNicknames | ChangeAvatar |
              RemoveAvatars | ViewChannel | ReadMessageHistory | SendMessage |
              ManageMessages | ManageWebhooks | InviteOthers | SendEmbeds |
              UploadFiles | Masquerade | UseReactions | Connect | Speak | Video |
              MuteMembers | DeafenMembers | MoveMembers
}