using System;
using DefaultEcs;
using System.Collections.Generic;
using Source.GGJ2020.Features.RenderFeature;
using Source.Common;
using Source.Common.Extensions;
using Source.GGJ2020.Features.RenderFeature.Components;
using Source.GGJ2020.Messages;
using UnityEngine;

namespace Source.Unity.Views {
    public abstract class EntityView : MonoBehaviour, IRenderable {
        public Entity LinkedEntity;

        private void Awake() {
            Container.Resolve<World>().Subscribe<WorldInitializedMessage>(OnWorldInitialized);
        }

        public void LinkTo(Entity? possibleEntity) {
            if (possibleEntity == null) {
                Debug.LogWarning("Not linked!");
                return;
            }

            Entity entity = (Entity) possibleEntity;
            ViewComponent view = entity.Has<ViewComponent>()
                ? entity.Get<ViewComponent>()
                : new ViewComponent {Value = new HashSet<IRenderable>()};

            foreach (IRenderable renderable in gameObject.GetComponentsInChildren<IRenderable>()) {
                view.Value.Add(renderable);
            }

            entity.Set(view);
        }

        public void SetEntity(Entity entity) {
            if (LinkedEntity != entity) {
                LinkedEntity = entity;
                OnLink(entity);
            }
        }

        public void LinkTo(EntitySetBuilder builder) {
            Entity? entity = builder.AsSet().First();
            if (entity != null) {
                LinkTo((Entity) entity);
            }
        }

        protected virtual void OnWorldInitialized(in WorldInitializedMessage message) {
        }

        protected virtual void OnLink(Entity entity) {
            Render(entity);
        }

        public virtual void OnComponentAdded<T>(T component) {
            Render(LinkedEntity);
        }

        public virtual void OnComponentUpdated<T>(T component) {
            Render(LinkedEntity);
        }

        public virtual void OnComponentRemoved<T>() {
            Render(LinkedEntity);
        }

        public abstract void Render(Entity entity);

        private void OnDestroy() {
            if (LinkedEntity != null) {
                LinkedEntity.Dispose();
            }
        }
    }
}