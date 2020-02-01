using DefaultEcs;
using Source.GGJ2020.Features.RenderFeature.Components;
using Source.GGJ2020.Features.SquadFeature.Components;
using Source.Unity;

namespace Source.GGJ2020.Factories {
    public class SkeletonFactory {
        private readonly World _world;

        public SkeletonFactory(World world) {
            _world = world;
        }

        public Entity MakeSkeleton() {
            Entity skeleton = _world.CreateEntity();
            skeleton.Set(new SkeletonComponent());
            skeleton.Set(new ViewResourceComponent {
                Value = GameConfig.Instance.SkeletonPrefab
            });
            return skeleton;
        }
    }
}