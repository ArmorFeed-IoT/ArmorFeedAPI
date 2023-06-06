using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace ArmorFeedApi.Geolocation.Utils
{
    public class GeolocationSocketManager
    {
        private readonly ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();
        private readonly ILogger _logger;
        public GeolocationSocketManager(ILogger<GeolocationSocketManager> logger) { 
            _logger = logger;
        }
        public void AddSocket(string connectionId, WebSocket socket)
        {
            _sockets.TryAdd(connectionId, socket);
        }

        public void RemoveSocket(string connectionId)
        {
            _sockets.TryRemove(connectionId, out _);
        }

        public async Task SendMessageAsync(string connectionId, object data)
        {
            if (_sockets.TryGetValue(connectionId, out WebSocket socket) && socket.State == WebSocketState.Open)
            {
                string message = JsonConvert.SerializeObject(data);
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
            }
            _logger.LogInformation("Socket with connection Id {} was not found", connectionId);
        }
    }
}
