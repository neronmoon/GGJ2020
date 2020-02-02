using System;
using System.Collections.Generic;
using System.Linq;
using DefaultEcs;
using DG.Tweening;
using Source.Common;
using Source.GGJ2020.Messages;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Unity.Views {
    public class LichZone : MonoBehaviour {
        public List<string> Items;

        [TextArea] public List<string> recepies;
        private System.Random r = new System.Random();

        public CanvasGroup CanvasGroup;
        public TextMeshProUGUI Text;
        public TextMeshProUGUI TutorialText;
        public Button CloseButton;

        private void Awake() {
            CloseButton.onClick.AddListener(OnCloseButton);
        }

        private void Start() {
            Container.Resolve<World>()
                     .Subscribe(delegate(in SkeletonSpawnedMessage message) {
                         TutorialText.text = getTrackerText();
                     });
        }

        private void OnTriggerEnter2D(Collider2D other) {
            SkeletonView skeleton = other.GetComponent<SkeletonView>();
            if (skeleton != null && skeleton.Item != null) {
                Items.Remove(skeleton.Item.Name);
                Destroy(skeleton.Item.gameObject);
                skeleton.Item = null;
                Text.text = getTrackerText();
                ShowRecepy();
            }

            if (Items.Count < 1) {
                YouWin();
            }
        }

        public string getTrackerText() {
            return "Bring me " + String.Join(", ", Items);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.X)) {
                OnCloseButton();
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

        private void YouWin() {
            CanvasGroup.DOFade(1f, 0.5f);
            Text.text = "Thanks for playing!";
            CloseButton.onClick.RemoveAllListeners();
            CloseButton.onClick.AddListener(delegate { Application.Quit(); });
        }

        private void OnCloseButton() {
            CanvasGroup.DOFade(0f, 0.5f);
            CanvasGroup.gameObject.SetActive(false);
            GameConfig.Instance.CanInteract = true;
        }
    }
}