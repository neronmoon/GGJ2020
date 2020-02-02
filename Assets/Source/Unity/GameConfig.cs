using Source.Unity.Common;
using Source.Unity.DataObjects;
using UnityEngine;

namespace Source.Unity
{
    public class GameConfig : MonoBehaviourSingleton<GameConfig> {
        public int MaxSkeletonsCount = 3;
        
        public CircleCollider2D SkeletonSpawnArea;
        public GameObject SkeletonPrefab;
        public GameObject ActionHandlePrefab;

        public bool BlockInteractions = false;
        
        
        [SerializeField]
        private GameData _gameData = null;

        public static GGJ2020.GameData GetGameData()
        {
            return Instance._gameData.GetData();
        }
    }
}