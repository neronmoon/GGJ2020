using DefaultEcs;
using DefaultEcs.System;
using Source.GGJ2020.Features.MovementFeature.Components;
using Source.GGJ2020.Features.RenderFeature.Components;
using UnityEngine;

namespace Source.GGJ2020.Features.RenderFeature {
    public class InstantiateViewSystem : AEntitySystem<float> {
        private World _world;

        public InstantiateViewSystem(World world) : base(GetEntities(world)) {
            _world = world;
        }

        private static EntitySet GetEntities(World world) {
            return world.GetEntities().With<ViewResourceComponent>().AsSet();
        }

        protected override void Update(float state, in Entity entity) {
            ViewResourceComponent resource = entity.Get<ViewResourceComponent>();

            var go = Object.Instantiate(resource.Value);
            if (entity.Has<PositionComponent>()) {
                var pos = entity.Get<PositionComponent>();
                go.transform.position = new Vector3(pos.Value.x, pos.Value.y, 0f);                
            }
            
            foreach (IRenderable renderable in go.GetComponentsInChildren<IRenderable>()) {
                renderable.LinkTo(entity);
            }

            entity.Remove<ViewResourceComponent>();
        }
    }
}