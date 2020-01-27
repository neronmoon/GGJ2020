using DefaultEcs;
using DefaultEcs.System;
using Source.GGJ2020.Features.RenderFeature.Components;
using Source.GGJ2020.Features.TimeFeature.Components;

namespace Source.GGJ2020.Features.InitializeFeature
{
    public class InitializeGameSystem : ISystem<float>
    {
        public bool IsEnabled { get; set; } = true;
        private readonly World _world;

        public InitializeGameSystem(World world)
        {
            _world = world;
        }

        public void Update(float state)
        {
            Entity entity = _world.CreateEntity();
            entity.Set(new ViewResourceComponent {Value = Game.Config.TestPrefab});
            entity.Set(new TimeoutComponent {Value = Game.Data.TestDisposeTime});
        }

        public void Dispose() { }
    }
}