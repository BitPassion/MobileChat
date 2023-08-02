﻿using MobileChat.Shared.Models;

namespace MobileChat.Shared.Interfaces
{
    public interface IChatHub
    {
        //users
        Task<KeyValuePair<Guid, bool>> SignUp(string displayname, string username, string email, string password);
        Task<KeyValuePair<Guid, bool>> SignIn(string emailorusername, string password);
        Task<bool> ChangePassword(string emailorusername, string newpassword);
        Task<string> GetUserDisplayName(Guid userId);
        Task<string> GetUserUsername(Guid userId);
        Task<bool> AddFriend(Guid userId, string friendEmailorusername);
        Task<bool> RemoveFriend(Guid userId, string friendEmailorusername);
        Task<UserFriend[]> GetUserFriends(Guid userId);
        //channels
        Task<Channel> CreateChannel(Guid userId, params string[] usernames);
        Task<bool> AddChannelUsers(Guid userid, Guid channelid, params string[] usernames);
        Task<bool> ChannelContainUser(Guid userid);
        Task<User[]> GetChannelUsers(Guid channelid);
        Task<Channel[]> GetUserChannels(Guid userid);
        //messages
        Task<bool> SendMessage(Message message);
        Task<bool> UpdateMessage(Message message);
        Task<Message[]> ReceiveMessageHistory(Guid channelId);
        Task<Message[]> ReceiveMessageHistoryRange(Guid channelId, int index, int range);
    }
}
