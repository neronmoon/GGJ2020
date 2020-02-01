using Source.GGJ2020.Features.ActionsFeature.Components;
using TMPro;
using UnityEngine;

namespace Source.Unity.Views.UI {
    public class ActionItemUI : MonoBehaviour {
        public Color SelectedColor;
        private Color NotSelectedColor;

        public TextMeshProUGUI Text;

        private void Awake() {
            NotSelectedColor = Text.color;
        }

        public void Initialize(IAction action) {
            Text.text = action.GetName();
        }

        public void SetSelected(bool isSelected) {
            Text.color = isSelected ? SelectedColor : NotSelectedColor;
        }
    }
}