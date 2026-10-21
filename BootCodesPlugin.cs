using System.Threading.Tasks;
using Impostor.Api.Plugins;
using Microsoft.Extensions.Logging;

namespace Boot.Codes
{
    [ImpostorPlugin("at.duikbo.codes")]
    public class BootCodesPlugin : PluginBase
    {
        private readonly ILogger<BootCodesPlugin> _logger;

        private readonly IGameCodeManager _manager;

        public BootCodesPlugin(ILogger<BootCodesPlugin> logger, IGameCodeManager manager)
        {
            this._logger = logger;
            this._manager = manager;
        }

        public override ValueTask EnableAsync()
        {
            _logger.LogInformation(
                "Boot.Codes: loaded {SixCharCodes} 6-char codes from {Path}!",
                _manager.SixCharCodes, _manager.Path);
            return default;
        }
    }
}
