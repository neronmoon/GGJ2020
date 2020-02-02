using System;
using UnityEngine;

namespace Source.Unity.Views {
    public class DoorTrigger : MonoBehaviour {
        public DoorPosition[] Doors;
        public bool ShouldStandToOpen = true;

        private void OnTriggerEnter2D(Collider2D collision) {
            foreach (var door in Doors) {
                door.Open();
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if (!ShouldStandToOpen) {
                return;
            }
            foreach (var door in Doors) {
                door.Close();
            }
        }
    }
}