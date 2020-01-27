using System;
using System.Linq;
using DefaultEcs;
using Source.GGJ2020.Features.RenderFeature.Components;

namespace Source.GGJ2020.Features.RenderFeature
{
    public class GGJ2020EntityMutator : EntityMutator
    {
        public override void Set<T>(Entity entity, in T component)
        {
            var isUpdate = entity.Has<T>();
            base.Set(entity, component);
            HandleSet<T>(isUpdate, entity);
        }

        public override void SetSameAs<T>(Entity target, in Entity reference)
        {
            var isUpdate = target.Has<T>();
            base.SetSameAs<T>(target, reference);
            HandleSet<T>(isUpdate, target);
        }

        public override void Remove<T>(Entity entity)
        {
            base.Remove<T>(entity);
            CallOnEntityBehaviours(entity, delegate(IRenderable behaviour) { behaviour.OnComponentRemoved<T>(); });
        }

        private void HandleSet<T>(bool isUpdate, Entity entity)
        {
            T comp = entity.Get<T>();

            CallOnEntityBehaviours(entity, delegate(IRenderable beh)
            {
                if (isUpdate) {
                    beh.OnComponentUpdated(comp);
                } else {
                    beh.OnComponentAdded(comp);
                }
            });
        }

        private void CallOnEntityBehaviours(Entity entity, Action<IRenderable> callback)
        {
            if (entity.Has<ViewComponent>()) {
                var views = entity.Get<ViewComponent>().Value.ToArray();
                for (int i = 0; i < views.Length; i++) {
                    var view = views[i];
                    if (view != null) {
                        view.SetEntity(entity);
                        callback.Invoke(view);
                    }
                }
            }
        }
    }
}