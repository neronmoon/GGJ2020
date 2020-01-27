using Source.Unity.Common;
using Source.Unity.DataObjects;
using UnityEngine;

namespace Source.Unity
{
    public class GameConfig : MonoBehaviourSingleton<GameConfig>
    {
        // TODO GameConfig options goes here
        public GameObject TestPrefab;

        [SerializeField]
        private GameData _gameData = null;

        public static TemplateGame.GameData GetGameData()
        {
            return Instance._gameData.GetData();
        }
    }
}