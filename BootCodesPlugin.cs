using System.Threading.Tasks;
using Boot.Codes.Handlers;
using Impostor.Api.Events.Managers;
using Impostor.Api.Plugins;
using Microsoft.Extensions.Logging;

namespace Boot.Codes
{
    [ImpostorPlugin("at.duikbo.codes")]
    public class BootCodesPlugin : PluginBase
    {
        private readonly ILogger<BootCodesPlugin> _logger;

        private readonly IGameCodeManager _manager;

        public BootCodesPlugin(ILogger<BootCodesPlugin> logger, IGameCodeManager manager, IEventManager eventManager, GameEventListener eventListener)
        {
            this._logger = logger;
            this._manager = manager;
            eventManager.RegisterListener(eventListener);
        }

        public override ValueTask EnableAsync()
        {
            var sum = _manager.FourCharCodes + _manager.SixCharCodes;
            _logger.LogInformation(
                "Boot.Codes: loaded {FourCharCodes} 4-char codes and {SixCharCodes} 6-char codes [{Total} total] from {Path}!",
                _manager.FourCharCodes, _manager.SixCharCodes, sum, _manager.Path);
            return default;
        }
    }
}
