using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Source.Unity.Views {
    public class DoorPosition : MonoBehaviour {
        public Tile DoorTile;

        public bool IsOpen = false;
        
        public void Open() {
            Tilemap map = GameConfig.Instance.NonWalkableTilemap;
            TileBase tile = map.GetTile(map.WorldToCell(transform.position));
            map.SetTile(map.WorldToCell(transform.position), null);
            IsOpen = true;
        }

        public void Close() {
            IsOpen = false;
            Tilemap map = GameConfig.Instance.NonWalkableTilemap;
            TileBase tile = map.GetTile(map.WorldToCell(transform.position));
            map.SetTile(map.WorldToCell(transform.position), DoorTile);
        }

        private void OnDrawGizmos() {
            Gizmos.DrawSphere(transform.position, 0.5f);
        }
    }
}