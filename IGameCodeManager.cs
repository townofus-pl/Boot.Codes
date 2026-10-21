using Impostor.Api.Games;

namespace Boot.Codes
{
    public interface IGameCodeManager
    {
        int SixCharCodes { get; }

        string Path { get; }

        GameCode Get();

        void Release(GameCode code);
    }
}