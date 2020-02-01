using System.Collections.Generic;
using DefaultEcs;
using Source.Common.Extensions;
using Source.GGJ2020.Features.SquadFeature.Components;
using Source.GGJ2020.Messages;
using UnityEngine;

namespace Source.Unity.Views.UI {
    public class SkeletonUIPanelView : EntityView {
        public GameObject SkeletonUIPrefab;

        private Dictionary<Entity, SkeletonUIView> views = new Dictionary<Entity, SkeletonUIView>(5);

        protected override void OnWorldInitialized(in WorldInitializedMessage message) {
            LinkTo(message.World.FindOne(w => w
                .With<SkeletonSquadComponent>()
            ));
        }

        public override void Render(Entity entity) {
            foreach (var skeletonEntity in entity.Get<SkeletonSquadComponent>().Value) {
                if (!views.ContainsKey(skeletonEntity)) {
                    Debug.Log("Spawn UI");
                    var ui = Instantiate(SkeletonUIPrefab, transform);
                    var view = ui.GetComponent<SkeletonUIView>();
                    view.LinkTo(skeletonEntity);
                    views.Add(skeletonEntity, view);
                }
            }
        }
    }
}