using DefaultEcs;
using DG.Tweening;
using Source.Common;
using Source.Common.Extensions;
using Source.GGJ2020.Commands;
using Source.GGJ2020.Features.ActionsFeature.Components;
using Source.GGJ2020.Features.MovementFeature;
using Source.GGJ2020.Features.MovementFeature.Components;
using Source.GGJ2020.Messages;
using UnityEngine;

namespace Source.Unity.Views {
    public class ActionHandleView : EntityView {
        private void Awake() {
            World world = Container.Resolve<World>();
            world.Subscribe<CancelMessage>(delegate {
                if (!gameObject.activeSelf) return;
                Destroy(gameObject);
            });
            

            world.Subscribe<SubmitMessage>(delegate {
                if (!gameObject.activeSelf) return;
                HandleComponent handle = LinkedEntity.Get<HandleComponent>();
                handle.Entity.ApplyCommand(new ProcessActionCommand(
                    handle.Action,
                    LinkedEntity.Get<PositionComponent>().Value
                ));

                gameObject.SetActive(false);
            });
        }

        public override void Render(Entity entity) {
            transform.DOMove(PositionCalculator.Calculate(entity.Get<PositionComponent>().Value), 0.1f);
        }
    }
}