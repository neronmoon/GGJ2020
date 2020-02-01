using DefaultEcs;
using Source.Common;
using Source.Common.Extensions;
using Source.GGJ2020.Commands;
using Source.GGJ2020.Features.SquadFeature.Components;
using Source.GGJ2020.Messages;
using UnityEngine;

namespace Source.Unity {
    public class InputRegistrar : MonoBehaviour {
        public KeyCode SpawnSkeletonKey;
        public KeyCode NextSkeletonKey;

        private World _world;
        private Entity _skeletonSquad;

        private void Awake() {
            _world = Container.Resolve<World>();
            _world.Subscribe<WorldInitializedMessage>(OnWorldInitialized);
        }

        protected virtual void OnWorldInitialized(in WorldInitializedMessage message) {
            _skeletonSquad = _world.GetEntities().With<SkeletonSquadComponent>().AsSet().First();
        }

        private void Update() {
            if (Input.GetKeyDown(SpawnSkeletonKey)) {
                _skeletonSquad.ApplyCommand(new SpawnSkeletonCommand());
            }
            if (Input.GetKeyDown(NextSkeletonKey)) {
                _skeletonSquad.ApplyCommand(new SelectNextSkeletonCommand());
            }
        }
    }
}