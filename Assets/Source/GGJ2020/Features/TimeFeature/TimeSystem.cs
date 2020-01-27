using DefaultEcs;
using DefaultEcs.System;
using Source.GGJ2020.Features.TimeFeature.Components;

namespace Source.GGJ2020.Features.RenderFeature
{
    public class TimeSystem : AEntitySystem<float>
    {
        private World _world;

        public TimeSystem(World world) : base(GetEntities(world))
        {
            _world = world;
        }

        private static EntitySet GetEntities(World world)
        {
            return world.GetEntities().WithEither(typeof(CurrentTimeComponent), typeof(TimeoutComponent)).AsSet();
        }

        protected override void Update(float dt, in Entity entity)
        {
            if (entity.Has<CurrentTimeComponent>()) {
                float time = entity.Get<CurrentTimeComponent>().Value + dt;
                entity.Set(new CurrentTimeComponent {Value = time});
            }

            if (entity.Has<TimeoutComponent>()) {
                float time = entity.Get<TimeoutComponent>().Value - dt;
                if (time <= 0) {
                    entity.Remove<TimeoutComponent>();
                } else {
                    entity.Set(new TimeoutComponent {Value = time});
                }
            }
        }
    }
}