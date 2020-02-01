using System.Collections.Generic;
using DefaultEcs;
using DefaultEcs.System;
using Source.GGJ2020.Features.ActionsFeature.Components;
using Source.GGJ2020.Features.SquadFeature.Components;

namespace Source.GGJ2020.Features.GameFeature
{
    public class InitializeGameSystem : ISystem<float>
    {
        public bool IsEnabled { get; set; } = true;
        private readonly World _world;

        public InitializeGameSystem(World world)
        {
            _world = world;
        }

        public void Update(float state)
        {
            Entity skeletonSquad = _world.CreateEntity();
            skeletonSquad.Set(new SkeletonSquadComponent());
            skeletonSquad.Set(new ActionsContainerComponent {
                Value = new List<IAction> {
                    new GoToAction(),
                    new BringAction()
                }
            });

        }

        public void Dispose() { }
    }
}