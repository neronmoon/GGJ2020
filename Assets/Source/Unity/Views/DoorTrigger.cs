using System;
using UnityEngine;

namespace Source.Unity.Views {
    public class DoorTrigger : MonoBehaviour {
        public DoorPosition Door;

        private void OnTriggerEnter2D(Collider2D collision) {
            Door.Open();
        }
        private void OnTriggerExit2D(Collider2D collision) {
            Door.Close();
        }
    }
}