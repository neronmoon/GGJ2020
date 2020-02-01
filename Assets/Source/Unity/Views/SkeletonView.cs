using DefaultEcs;
using DG.Tweening;
using Source.Common;
using Source.Common.Extensions;
using Source.GGJ2020.Features.ActionsFeature.Components;
using Source.GGJ2020.Features.MovementFeature;
using Source.GGJ2020.Features.MovementFeature.Components;
using Source.GGJ2020.Messages;
using Source.Unity.Views.UI;
using UnityEngine;

namespace Source.Unity.Views {
    public class SkeletonView : EntityView {
        public GameObject ActionsMenu;

        private void Awake() {
            Container.Resolve<World>().Subscribe<TriggerActionsMessage>(TriggerActionsMenu);
        }

        private void TriggerActionsMenu(in TriggerActionsMessage message) {
            bool isThisSkeleton = message.SkeletonEntity == LinkedEntity;
            ActionsMenu.SetActive(isThisSkeleton);
            if (isThisSkeleton) {
                var ui = ActionsMenu.GetComponent<ActionsMenuUI>();
                ui.LinkTo(LinkedEntity.World.FindOne(w => w.With<ActionsContainerComponent>()));
                ui.SetSkeletonEntity(message.SkeletonEntity);
                ui.Reset();
            }
        }

        public override void Render(Entity entity) {
            if (entity.Has<CurrentMovementTargetComponent>()) {
                transform.DOMove(
                    PositionCalculator.Calculate(entity.Get<CurrentMovementTargetComponent>().Value),
                    0.2f
                );
                // animate
            }
        }
    }
}