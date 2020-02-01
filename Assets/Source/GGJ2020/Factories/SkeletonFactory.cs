using DefaultEcs;
using Source.GGJ2020.Features.MovementFeature.Components;
using Source.GGJ2020.Features.RenderFeature.Components;
using Source.GGJ2020.Features.SquadFeature.Components;
using Source.Unity;
using UnityEngine;

namespace Source.GGJ2020.Factories {
    public class SkeletonFactory {
        private readonly World _world;

        public SkeletonFactory(World world) {
            _world = world;
        }

        public Entity MakeSkeleton() {
            Entity skeleton = _world.CreateEntity();
            skeleton.Set(new SkeletonComponent());

            CircleCollider2D area = GameConfig.Instance.SkeletonSpawnArea;

            skeleton.Set(new PositionComponent {
                Value = Random.insideUnitCircle * area.radius + area.offset
            });
            skeleton.Set(new ViewResourceComponent {
                Value = GameConfig.Instance.SkeletonPrefab,
            });

            return skeleton;
        }
    }
}