using DefaultEcs;
using DefaultEcs.System;
using Source.GGJ2020.Features.MovementFeature.Components;
using Source.GGJ2020.Features.RenderFeature;
using Source.GGJ2020.Features.RenderFeature.Components;
using Source.GGJ2020.Features.SquadFeature.Components;

namespace Source.GGJ2020.Features.MovementFeature {
    public class MoveSkeletonSystem : AEntitySystem<float> {
        private World _world;

        public MoveSkeletonSystem(World world) : base(GetEntities(world)) {
            _world = world;
        }

        private static EntitySet GetEntities(World world) {
            return world.GetEntities()
                        .With<SkeletonComponent>()
                        .With<PositionComponent>()
                        .With<TargetPositionComponent>()
                        .AsSet();
        }

        protected override void Update(float state, in Entity entity) {
             // TODO
        }
    }
}