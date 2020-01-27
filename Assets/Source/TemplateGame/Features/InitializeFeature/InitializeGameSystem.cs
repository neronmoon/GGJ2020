using DefaultEcs;
using DefaultEcs.System;
using Source.TemplateGame.Features.RenderFeature.Components;
using Source.TemplateGame.Features.TimeFeature.Components;

namespace Source.TemplateGame.Features.InitializeFeature
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