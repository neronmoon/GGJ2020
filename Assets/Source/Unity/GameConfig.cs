using Source.Unity.Common;
using Source.Unity.DataObjects;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Source.Unity
{
    public class GameConfig : MonoBehaviourSingleton<GameConfig> {
        public int MaxSkeletonsCount = 2;
        
        public CircleCollider2D SkeletonSpawnArea;
        public GameObject SkeletonPrefab;
        public GameObject ActionHandlePrefab;

        public Tilemap NonWalkableTilemap;
        public Tilemap TriggersTilemap;

        public bool CanInteract = true;
        
        [SerializeField]
        private GameData _gameData = null;

        public static GGJ2020.GameData GetGameData()
        {
            return Instance._gameData.GetData();
        }
    }
}