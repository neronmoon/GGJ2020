using DefaultEcs;
using DefaultEcs.System;
using Source.GGJ2020.Features.SquadFeature.Components;

namespace Source.GGJ2020.Features.SquadFeature {
    public class SpawnSkeletonSystem : AEntitySystem<float>
    {
        private World _world;

        public SpawnSkeletonSystem(World world) : base(GetEntities(world))
        {
            _world = world;
        }

        private static EntitySet GetEntities(World world)
        {
            return world.GetEntities().With<SkeletonComponent>().AsSet();
        }

        protected override void Update(float state, in Entity entity)
        {
            
        }
    }
}