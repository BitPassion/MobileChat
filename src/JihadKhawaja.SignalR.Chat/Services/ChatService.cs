﻿using JihadKhawaja.SignalR.Client.Chat.Interfaces;
using JihadKhawaja.SignalR.Client.Chat.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JihadKhawaja.SignalR.Client.Chat.Services
{
    internal class ChatService : IChat
    {
        public async Task<KeyValuePair<Guid, bool>> SignUp(string displayname, string username, string email, string password)
        {
            return await Core.SignalR.HubConnection.InvokeAsync<KeyValuePair<Guid, bool>>("SignUp", displayname, username, email, password);
        }

        public async Task<KeyValuePair<Guid, bool>> SignIn(string emailorusername, string password)
        {
            return await Core.SignalR.HubConnection.InvokeAsync<KeyValuePair<Guid, bool>>("SignIn", emailorusername, password);
        }

        public async Task<bool> SendMessage(Message message)
        {
            return await Core.SignalR.HubConnection.InvokeAsync<bool>("SendMessage", message);
        }

        public async Task<bool> AddFriend(Guid userId, string friendEmailorusername)
        {
            return await Core.SignalR.HubConnection.InvokeAsync<bool>("AddFriend", userId, friendEmailorusername);
        }

        public async Task<bool> RemoveFriend(Guid userId, string friendEmailorusername)
        {
            return await Core.SignalR.HubConnection.InvokeAsync<bool>("RemoveFriend", userId, friendEmailorusername);
        }

        public async Task<Channel> CreateChannel(Guid userId, params string[] usernames)
        {
            return await Core.SignalR.HubConnection.InvokeAsync<Channel>("CreateChannel", userId, usernames);
        }
        public async Task<User[]> GetChannelUsers(Guid channelid)
        {
            return await Core.SignalR.HubConnection.InvokeAsync<User[]>("GetChannelUsers", channelid);
        }

        public Task<Channel[]> GetUserChannels(Guid userid)
        {
            return Core.SignalR.HubConnection.InvokeAsync<Channel[]>("GetUserChannels", userid);
        }

        public async Task<Message[]> ReceiveMessageHistory(Guid channelid)
        {
            return await Core.SignalR.HubConnection.InvokeAsync<Message[]>("ReceiveMessageHistory", channelid);
        }

        public async Task<Message[]> ReceiveMessageHistoryRange(Guid channelid, int index, int range)
        {
            return await Core.SignalR.HubConnection.InvokeAsync<Message[]>("ReceiveMessageHistoryRange", channelid, index, range);
        }

        public Task<string> GetUserDisplayName(Guid userId)
        {
            return Core.SignalR.HubConnection.InvokeAsync<string>("GetUserDisplayName", userId);
        }
    }
}
