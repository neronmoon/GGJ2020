using System;
using UnityEngine;

namespace Source.Unity.Views {
    public class ItemView : MonoBehaviour {
        public string Name = "Item";


        private void OnTriggerEnter2D(Collider2D other) {
            SkeletonView skeletonView = other.gameObject.GetComponent<SkeletonView>();
            if (skeletonView != null) {
                skeletonView.AddItem(this);
            }
        }
    }
}