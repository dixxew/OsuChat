﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Linq;

namespace ChatWebServer.Hubs
{
    public class CommunicationHub : Hub<ICommunicationHub>
    {
        private readonly ChatManager _chatManager;
        private const string _defaultGroupName = "General";

        public CommunicationHub(ChatManager chatManager)
            => _chatManager = chatManager;

        #region overrides

        /// <summary>
        /// Called when a new connection is established with the hub.
        /// </summary>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous connect.</returns>
        public override async Task OnConnectedAsync()
        {
            var userName = "Anonymous";
            var connectionId = Context.ConnectionId;
            _chatManager.ConnectUser(userName, connectionId);
            await Groups.AddToGroupAsync(connectionId, _defaultGroupName);
            await base.OnConnectedAsync();
        }

        /// <summary>Called when a connection with the hub is terminated.</summary>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous disconnect.</returns>
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var isUserRemoved = _chatManager.DisconnectUser(Context.ConnectionId);
            if (!isUserRemoved)
            {
                await base.OnDisconnectedAsync(exception);
            }

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, _defaultGroupName);
            await base.OnDisconnectedAsync(exception);
        }
        
        #endregion

        public async Task UpdateChatsAsync()
        {
            var users = _chatManager.Users.Select(x => x.UserName).ToList();
            await Clients.All.UpdateUsersAsync(users);
        }     
        
        public async Task SendMessageAsync(int chat_id, int from_id, int to_id, string message_text, DateTime time) => 
            await Clients.All.SendMessageAsync("","");
    }
}
