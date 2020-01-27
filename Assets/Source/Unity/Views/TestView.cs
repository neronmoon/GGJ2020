using DefaultEcs;
using Source.Common.Extensions;
using UnityEngine;

namespace Source.Unity.Views
{
    public class TestView : EntityView
    {
        public override void Render(Entity entity)
        {
            Debug.Log(entity.Debug());
        }
    }
}