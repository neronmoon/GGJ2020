using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Unity.Views {
    public class LichZone : MonoBehaviour {
        public List<string> Items;

        private List<string> recepies;
        private System.Random r = new System.Random();

        public CanvasGroup CanvasGroup;
        public TextMeshProUGUI Text;
        public Button CloseButton;

        private void Awake() {
            recepies = new Recepies().Recepty;
            CloseButton.onClick.AddListener(OnCloseButton);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            SkeletonView skeleton = other.GetComponent<SkeletonView>();
            if (skeleton != null && skeleton.Item != null) {
                Items.Remove(skeleton.Item.Name);
                skeleton.Item = null;
                ShowRecepy();
            }
        }

        private void ShowRecepy() {
            GameConfig.Instance.CanInteract = false;
            CanvasGroup.gameObject.SetActive(true);
            CanvasGroup.DOFade(1f, 0.5f);
            int idx = r.Next(0, recepies.Count);
            Text.text = recepies[idx];
            recepies.RemoveAt(idx);
        }

        private void OnCloseButton() {
            CanvasGroup.DOFade(0f, 0.5f);
            CanvasGroup.gameObject.SetActive(false);
            GameConfig.Instance.CanInteract = true;
        }
    }
}