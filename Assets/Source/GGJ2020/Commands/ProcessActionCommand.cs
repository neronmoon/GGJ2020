using DefaultEcs;
using Source.GGJ2020.Features.ActionsFeature.Components;
using Source.GGJ2020.Features.MovementFeature.Components;
using Source.GGJ2020.Features.SquadFeature.Components;
using UnityEngine;

namespace Source.GGJ2020.Commands {
    public class ProcessActionCommand : ICommand {
        private readonly IAction _action;
        private readonly Vector2Int _targetPosition;

        public ProcessActionCommand(IAction action, Vector2Int targetPosition) {
            _action = action;
            _targetPosition = targetPosition;
        }

        public bool CheckConstraints(Entity entity) {
            return entity.Has<SkeletonComponent>() && entity.Has<PositionComponent>();
        }

        public void Apply(Entity entity) {
            // calculate path
            
            
            
            // move to position
            // take action
            // take post action
        }
    }
}