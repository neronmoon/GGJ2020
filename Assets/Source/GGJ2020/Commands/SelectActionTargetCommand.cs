using DefaultEcs;
using Source.GGJ2020.Features.ActionsFeature.Components;
using Source.GGJ2020.Features.MovementFeature.Components;
using Source.GGJ2020.Features.RenderFeature.Components;
using Source.GGJ2020.Features.SquadFeature.Components;
using Source.Unity;

namespace Source.GGJ2020.Commands {
    public class SelectActionTargetCommand : ICommand {
        private readonly IAction _action;

        public SelectActionTargetCommand(IAction action) {
            _action = action;
        }

        public bool CheckConstraints(Entity entity) {
            return entity.Has<SkeletonComponent>() && entity.Has<PositionComponent>();
        }

        public void Apply(Entity entity) {
            Entity handle = entity.World.CreateEntity();
            handle.Set(new HandleComponent {
                Entity = entity,
                Action = _action
            });
            handle.Set(new PositionComponent {
                Value = entity.Get<PositionComponent>().Value
            });
            
            handle.Set(new ViewResourceComponent {Value = GameConfig.Instance.ActionHandlePrefab});
        }
    }
}