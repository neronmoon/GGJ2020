using Source.GGJ2020;
using UnityEngine;

namespace Source.Unity
{
    public static class GameStarter
    {
        private static Game _game;

        private static UnityGameWorld _unityGameWorld;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void InitializeGame()
        {
            _game = new Game();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void CreateWorld()
        {
            _game.SetGameData(GameConfig.GetGameData());
            _game.SetGameConfig(GameConfig.Instance);
            _unityGameWorld = CreateUnityWorld();
            _unityGameWorld.OnStart += _game.OnStart;
            _unityGameWorld.OnTick += _game.OnTick;
            _unityGameWorld.OnQuit += _game.OnQuit;
        }

        private static UnityGameWorld CreateUnityWorld()
        {
            GameObject worldHolder = new GameObject("[GameWorld]");
            Object.DontDestroyOnLoad(worldHolder);
            return worldHolder.AddComponent<UnityGameWorld>();
        }
    }
}