using DefaultEcs;
using DG.Tweening;
using Source.Common;
using Source.Common.Extensions;
using Source.GGJ2020.Features.ActionsFeature.Components;
using Source.GGJ2020.Features.MovementFeature;
using Source.GGJ2020.Features.MovementFeature.Components;
using Source.GGJ2020.Features.SquadFeature.Components;
using Source.GGJ2020.Messages;
using UnityEngine;

namespace Source.Unity.Views {
    public class SkeletonView : EntityView {
        public GameObject ActionsMenu;

        private void Awake() {
            World world = Container.Resolve<World>();
            world.Subscribe<MoveMessage>(movement);
        }

        private void movement(in MoveMessage msg) {
            if (!LinkedEntity.Has<ActiveSkeletonComponent>()) return;
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
        }

        public override void Render(Entity entity) {
            transform.DOMove(PositionCalculator.Calculate(entity.Get<PositionComponent>().Value), 0.2f);
        }
    }
}