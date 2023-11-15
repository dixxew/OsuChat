
# OsuChat

Improved chat for injection into the overlay in the [osu!](https://github.com/ppy/osu) game using SignalR


## Concept


Client (WPF):
- The ability to inject the client into the game overlay.
- The main communication protocols are set by SignalR
- The ability to send pictures and files.
- Audio communication (calls) is possible
- The ability to use the standard IRC protocol for the chat (indication in the chat list) with the ability to send text messages.
Server(Asp.Net Core):
- Registration and authorization of the user in the service + additional authentication via osu! to get a list of chats and friends of the user. 
- AspNetCore account management.Identity
Storage:
- MongoDB - user messages
- MSSql - accounts, chat lists, etc.


## At the moment

Client
- Auth pages, Chat page, Side menu developed
- Base navigation
- Preliminary data models have been developed (may reworked)
- The ability to send a message to the server(reworking)
Server 
- A single hub has been created
- Preliminary data models for mssql and mongo have been developed
