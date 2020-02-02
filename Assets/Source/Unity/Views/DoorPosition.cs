using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Source.Unity.Views {
    public class DoorPosition : MonoBehaviour {
        public Tile DoorTile;

        public void Open() {
            Tilemap map = GameConfig.Instance.NonWalkableTilemap;
            TileBase tile = map.GetTile(map.WorldToCell(transform.position));
            map.SetTile(map.WorldToCell(transform.position), null);
        }

        public void Close() {
            Tilemap map = GameConfig.Instance.NonWalkableTilemap;
            TileBase tile = map.GetTile(map.WorldToCell(transform.position));
            map.SetTile(map.WorldToCell(transform.position), DoorTile);
        }

        private void OnDrawGizmos() {
            Gizmos.DrawSphere(transform.position, 0.5f);
        }
    }
}