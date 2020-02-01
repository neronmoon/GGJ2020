using System;
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

        public KeyCode SkeletonMenuKey;
        public KeyCode SubmitKey;
        public KeyCode CancelKey;

        private World _world;
        private Entity _skeletonSquad;

        private float LastTimeKey;

        private void Awake() {
            _world = Container.Resolve<World>();
            _world.Subscribe<WorldInitializedMessage>(OnWorldInitialized);
        }

        protected virtual void OnWorldInitialized(in WorldInitializedMessage message) {
            _skeletonSquad = (Entity) _world.FindOne(w => w.With<SkeletonSquadComponent>());
        }

        private void Update() {
            if (Input.GetKeyDown(SpawnSkeletonKey)) {
                _skeletonSquad.ApplyCommand(new SpawnSkeletonCommand());
            }

            if (Input.GetKeyDown(NextSkeletonKey)) {
                _skeletonSquad.ApplyCommand(new SelectNextSkeletonCommand());
            }

            if (Input.GetKeyDown(SkeletonMenuKey)) {
                Entity? activeSkeleton = _world.FindOne(w => w.With<ActiveSkeletonComponent>());
                if (activeSkeleton != null) {
                    _world.Publish(new TriggerAbilitiesMessage {SkeletonEntity = (Entity) activeSkeleton});
                }
            }

            if (Input.GetKeyDown(SubmitKey)) {
                _world.Publish(new SubmitMessage());
            }

            if (Input.GetKeyDown(CancelKey)) {
                _world.Publish(new CancelMessage());
            }

            handleArrows();
        }

        private void handleArrows() {
            if (Input.GetKey(KeyCode.UpArrow)) {
                Throttle(delegate { _world.Publish(new MoveMessage {Type = MovementType.Up}); });
            }

            if (Input.GetKey(KeyCode.DownArrow)) {
                Throttle(delegate { _world.Publish(new MoveMessage {Type = MovementType.Down}); });
            }

            if (Input.GetKey(KeyCode.LeftArrow)) {
                Throttle(delegate { _world.Publish(new MoveMessage {Type = MovementType.Left}); });
            }

            if (Input.GetKey(KeyCode.RightArrow)) {
                Throttle(delegate { _world.Publish(new MoveMessage {Type = MovementType.Right}); });
            }
        }

        private void Throttle(Action action) {
            if (Time.time >= LastTimeKey + 0.1f) {
                action.Invoke();
                LastTimeKey = Time.time;
            }
        }
    }
}