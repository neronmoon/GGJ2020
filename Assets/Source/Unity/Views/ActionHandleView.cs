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
            world.Subscribe(delegate(in MoveMessage msg) {
                if (!gameObject.activeSelf) return;
                Vector2Int target = Vector2Int.zero;
                if (msg.Type == MovementType.Down) {
                    target.y = -1;
                }

                if (msg.Type == MovementType.Up) {
                    target.y = 1;
                }

                if (msg.Type == MovementType.Right) {
                    target.x = 1;
                }

                if (msg.Type == MovementType.Left) {
                    target.x = -1;
                }

                Vector2Int targetPosition = LinkedEntity.Get<PositionComponent>().Value + target;
                LinkedEntity.Set(new PositionComponent {Value = targetPosition});
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

        private void Unsubscribe() {
            World world = Container.Resolve<World>();
        }

        public override void Render(Entity entity) {
            transform.DOMove(PositionCalculator.Calculate(entity.Get<PositionComponent>().Value), 0.1f);
        }
    }
}