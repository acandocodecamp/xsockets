# What is XSockets.NET
- XSockets.NET is a real-time messaging system that allows for communication between any device that supports TCP/IP.
- Full duplex communication -> websockets
- Half duplex -> AJAX
- Web socket support without being dependent on Windows and .NET versions
- Pluggable architecture

## Simple Hosting
- Console application
- OWIN
- Azure
- Web

## Controllers
- Handles connection with client, will live in memory for as long as the client is connected to it
- Can hold client state
- Model binding
- Events on connected/re-connected

## RPC and Pub/Sub
- Different patterns but can be used to accomplish much of the same functionality
- The big difference between RPC and Pub/Sub in XSockets is that messages will only arrive at the client if the client has a subscription registered on the server

## Offline Messages
- XSockets can store messages in-memory for clients being offline for a short period
- Switched off by default

## Scale-out
- Scale-out over websockets
- Can be done implementing interface IXSocketsScaleOut

## Comparison with SignalR
- Websockets everywhere, not only .NET 4.5 on Windows Server 2012+ or Windows 8+
- Pub/Sub (can be built on top of SignalR)
- Offline messages
- Server state (SignalR: Only persistent connection, groups)
- http://xsockets.net/xsockets-vs-signalr

## Lessons learnt
- ConfigurationSetting must be public (true for all plugins?)
- OWIN host will not pick up custom configuration unless initiated with new OwinHostConfiguration
- Project assembly name / namespace cannot contain "XSockets"
- Custom DI?
- Dont use javascsript API from bower
- V4 packages won't work in VS2015
- Opinionated?