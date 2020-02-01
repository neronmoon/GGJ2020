using DefaultEcs;
using Source.Common;
using Source.GGJ2020.Factories;
using Source.GGJ2020.Features.SquadFeature.Components;
using Source.Unity;

namespace Source.GGJ2020.Commands {
    public class SpawnSkeletonCommand : ICommand {
        private readonly SkeletonFactory _factory;

        public SpawnSkeletonCommand() {
            _factory = new SkeletonFactory(Container.Resolve<World>());
        }

        public bool CheckConstraints(Entity entity) {
            return entity.Has<SkeletonSquadComponent>() &&
                   entity.Get<SkeletonSquadComponent>().Value.Count < GameConfig.Instance.MaxSkeletonsCount;
        }

        public void Apply(Entity entity) {
            SkeletonSquadComponent squad = entity.Get<SkeletonSquadComponent>();
            foreach (var e in squad.Value) {
                if (e.Has<ActiveSkeletonComponent>()) {
                    e.Remove<ActiveSkeletonComponent>();
                }
            }

            Entity skeleton = _factory.MakeSkeleton();
            skeleton.Set(new ActiveSkeletonComponent());

            squad.Value.Add(skeleton);
            entity.Set(squad);
        }
    }
}