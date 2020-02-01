using DefaultEcs;
using DefaultEcs.System;
using Source.GGJ2020.Features.MovementFeature.Components;

namespace Source.GGJ2020.Features.MovementFeature {
    public class SetNextPathTargetSystem : AEntitySystem<float> {
        private World _world;

        public SetNextPathTargetSystem(World world) : base(GetEntities(world)) {
            _world = world;
        }

        private static EntitySet GetEntities(World world) {
            return world.GetEntities()
                        .With<PositionComponent>()
                        .With<MovementPathComponent>()
                        .Without<CurrentMovementTargetComponent>().AsSet();
        }

        protected override void Update(float dt, in Entity entity) {
            var positionComponent = entity.Get<PositionComponent>();
            var path = entity.Get<MovementPathComponent>().Value;
            int idx = path.FindIndex(pos => pos == positionComponent.Value);

            if (path.Count - 1 == idx) {
                entity.Remove<MovementPathComponent>();
                // trigger message
            } else {
                entity.Set(new CurrentMovementTargetComponent {Value = path[idx]});
            }
        }
    }
}