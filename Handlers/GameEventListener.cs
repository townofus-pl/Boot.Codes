using Impostor.Api.Events;

namespace Boot.Codes.Handlers
{
    public class GameEventListener : IEventListener
    {
        private readonly IGameCodeManager _gameCodeManager;

        public GameEventListener(IGameCodeManager gameCodeManager)
        {
            this._gameCodeManager = gameCodeManager;
        }

        // NOTE: if you want to override the results of Boot.Codes, register an event at a lower priority

        [EventListener(EventPriority.Highest)]
        public void OnGameCreated(IGameCreationEvent e) => e.GameCode = _gameCodeManager.Get();

        [EventListener(EventPriority.Highest)]
        public void OnGameDestroyed(IGameDestroyedEvent e) => _gameCodeManager.Release(e.Game.Code);
    }
}
