using DefaultEcs;
using Source.GGJ2020.Features.ActionsFeature.Components;
using Source.GGJ2020.Features.SquadFeature.Components;
using UnityEngine;

namespace Source.GGJ2020.Commands {
    public class ProcessActionCommand : ICommand {
        private readonly IAction _action;
        private readonly Vector2Int _position;

        public ProcessActionCommand(IAction action, Vector2Int position) {
            _action = action;
            _position = position;
        }

        public bool CheckConstraints(Entity entity) {
            return entity.Has<SkeletonComponent>();
        }

        public void Apply(Entity entity) {
            // move to position
            // take action
            // take post action
        }
    }
}