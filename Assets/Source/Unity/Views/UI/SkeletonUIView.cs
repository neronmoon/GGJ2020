using DefaultEcs;
using Source.GGJ2020.Features.SquadFeature.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Unity.Views.UI {
    public class SkeletonUIView : EntityView {
        public Color ActiveColor;
        private Color NotActiveColor;
        public Image BackgroundImage;

        private void Awake() {
            NotActiveColor = BackgroundImage.color;
        }

        public override void Render(Entity entity) {
            BackgroundImage.color = entity.Has<ActiveSkeletonComponent>() ? ActiveColor : NotActiveColor;
        }
    }
}