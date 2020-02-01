using System.Collections.Generic;
using DefaultEcs;
using Source.Common;
using Source.GGJ2020.Factories;
using Source.GGJ2020.Features.SquadFeature.Components;

namespace Source.GGJ2020.Commands {
    public class SelectNextSkeletonCommand : ICommand {
        private readonly SkeletonFactory _factory;

        public SelectNextSkeletonCommand() {
            _factory = new SkeletonFactory(Container.Resolve<World>());
        }

        public bool CheckConstraints(Entity entity) {
            return entity.Has<SkeletonSquadComponent>();
        }

        public void Apply(Entity entity) {
            List<Entity> squad = entity.Get<SkeletonSquadComponent>().Value;
            for (int i = 0; i < squad.Count; i++) {
                if (squad[i].Has<ActiveSkeletonComponent>()) {
                    int nextId = (i + 1) % squad.Count;
                    squad[nextId].Set(new ActiveSkeletonComponent());
                    squad[i].Remove<ActiveSkeletonComponent>();
                    return;
                }
            }
        }
    }
}