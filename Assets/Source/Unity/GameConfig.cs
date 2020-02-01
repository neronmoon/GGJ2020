using Source.Unity.Common;
using Source.Unity.DataObjects;
using UnityEngine;

namespace Source.Unity
{
    public class GameConfig : MonoBehaviourSingleton<GameConfig>
    {
        public CircleCollider2D SkeletonSpawnArea;
        public GameObject SkeletonPrefab;
        
        
        [SerializeField]
        private GameData _gameData = null;

        public static GGJ2020.GameData GetGameData()
        {
            return Instance._gameData.GetData();
        }
    }
}