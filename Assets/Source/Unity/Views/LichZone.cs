using System.Collections.Generic;
using UnityEngine;

namespace Source.Unity.Views {
    public class LichZone : MonoBehaviour {
        public List<string> Items;
        
        private void OnTriggerEnter2D(Collider2D other) {
            SkeletonView skeleton = other.GetComponent<SkeletonView>();
            if (skeleton != null && skeleton.Item != null) {
                Items.Remove(skeleton.Item.Name);
                skeleton.Item = null;
            }
        }
    }
}