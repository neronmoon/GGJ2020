using DefaultEcs;
using DefaultEcs.System;
using Source.Common;
using Source.GGJ2020.Features.InitializeFeature;
using Source.GGJ2020.Features.RenderFeature;
using Source.GGJ2020.Messages;
using Source.Unity;

namespace Source.GGJ2020
{
    public class Game
    {
        private readonly World _world;
        private readonly SequentialSystem<float> _initSystem;
        private readonly SequentialSystem<float> _runtimeSystem;
        private readonly SequentialSystem<float> _cleanupSystem;

        public static GameData Data => Container.Resolve<GameData>();
        public static GameConfig Config => Container.Resolve<GameConfig>();

        public Game()
        {
            _world = new World();
            _world.SetEntityMutator(new GGJ2020EntityMutator());
            var container = Container.Instance;
            container.Register(typeof(World), () => _world).AsSingleton();
            _initSystem = MakeInitializeSystem(_world);
            _runtimeSystem = MakeRuntimeSystem(_world);
            _cleanupSystem = MakeCleanupSystem(_world);
        }

        public void SetGameData(GameData gameData)
        {
            Container.Instance.Register(typeof(GameData), () => gameData).AsSingleton();
        }

        public void SetGameConfig(GameConfig gameConfig)
        {
            Container.Instance.Register(typeof(GameConfig), () => gameConfig).AsSingleton();
        }

        public void OnStart()
        {
            _initSystem.Update(0);
            _world.Publish(new WorldInitializedMessage {World = _world});
        }

        public void OnTick(float dt)
        {
            _runtimeSystem.Update(dt);
        }

        public void OnQuit()
        {
            _cleanupSystem.Update(0);
        }

        private SequentialSystem<float> MakeInitializeSystem(World world)
        {
            // TODO Register initialization systems here
            return new SequentialSystem<float>(
                new InitializeGameSystem(world)
            );
        }

        private SequentialSystem<float> MakeRuntimeSystem(World world)
        {
            // TODO Register runtime systems here
            return new SequentialSystem<float>(
                new InstantiateViewSystem(world),
                new TimeSystem(world)
            );
        }

        private SequentialSystem<float> MakeCleanupSystem(World world)
        {
            return new SequentialSystem<float>(
                // new CleanupGameSystem(world)
            );
        }
    }
}