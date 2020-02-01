using DefaultEcs;
using Source.Common;
using Source.GGJ2020.Factories;
using Source.GGJ2020.Features.SquadFeature.Components;

namespace Source.GGJ2020.Commands {
    public class SpawnSkeletonCommand : ICommand {
        private readonly SkeletonFactory _factory;

        public SpawnSkeletonCommand() {
            _factory = new SkeletonFactory(Container.Resolve<World>());
        }

        public bool CheckConstraints(Entity entity) {
            return entity.Has<SkeletonSquadComponent>();
        }

        public void Apply(Entity entity) {
            Entity skeleton = _factory.MakeSkeleton();
            var squad = entity.Get<SkeletonSquadComponent>();
            squad.Skeletons.Add(skeleton);
            entity.Set(squad);
        }
    }
}