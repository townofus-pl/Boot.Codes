using System.Collections.Generic;
using Impostor.Api.Events;
using Impostor.Api.Games;
using Microsoft.Extensions.Logging;

namespace Boot.Codes.Handlers
{
    public class GameEventListener : IEventListener
    {
        private readonly IGameCodeManager _gameCodeManager;
        private readonly ILogger<GameEventListener> _logger;
        private readonly Dictionary<int, GameCode> _assignmentMap = new();

        public GameEventListener(IGameCodeManager gameCodeManager, ILogger<GameEventListener> logger)
        {
            _gameCodeManager = gameCodeManager;
            _logger = logger;
        }

        // NOTE: if you want to override the results of Boot.Codes, register an event at a lower priority
        [EventListener(EventPriority.Highest)]
        public void OnGameCreation(IGameCreationEvent e)
        {
            var code = _gameCodeManager.Get();
            e.GameCode = code;
            if (e.Client != null)
            {
                _assignmentMap[e.Client.Id] = code;
            }
        }

        [EventListener]
        public void OnGameCreated(IGameCreatedEvent e)
        {
            if (e.Host != null)
            {
                var hostId = e.Host.Id;
                if (_assignmentMap.Remove(hostId, out var expectedCode) && expectedCode != e.Game.Code)
                {
                    _logger.LogInformation("Boot.Codes provided code was overridden in game {Code}", e.Game.Code);
                    _gameCodeManager.Release(expectedCode);
                }
            }
        }

        [EventListener]
        public void OnGameDestroyed(IGameDestroyedEvent e) => _gameCodeManager.Release(e.Game.Code);
    }
}
