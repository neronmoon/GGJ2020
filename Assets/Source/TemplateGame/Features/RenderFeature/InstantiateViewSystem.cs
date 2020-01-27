using DefaultEcs;
using DefaultEcs.System;
using Source.TemplateGame.Features.RenderFeature.Components;

namespace Source.TemplateGame.Features.RenderFeature
{
    public class InstantiateViewSystem : AEntitySystem<float>
    {
        private World _world;

        public InstantiateViewSystem(World world) : base(GetEntities(world))
        {
            _world = world;
        }

        private static EntitySet GetEntities(World world)
        {
            return world.GetEntities().With<ViewResourceComponent>().AsSet();
        }

        protected override void Update(float state, in Entity entity)
        {
            ViewResourceComponent resource = entity.Get<ViewResourceComponent>();

            UnityEngine.GameObject go = UnityEngine.Object.Instantiate(resource.Value);
            foreach (IRenderable renderable in go.GetComponentsInChildren<IRenderable>()) {
                renderable.LinkTo(entity);
            }

            entity.Remove<ViewResourceComponent>();
        }
    }
}