using System;
using GData;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace Source.Unity.DataObjects
{
    [CreateAssetMenu(menuName = "GGJ2020/GameDataAsset", fileName = "GameData")]
    public class GameData : ScriptableObject
    {
        [BoxGroup("GData"), InspectorName("SpreadsheetId")]
        public string GDataSpreadsheetId;

        [BoxGroup("GData"), InspectorName("ApiKey")]
        public string GDataApiKey;

        [Space(10), SerializeField]
        private GGJ2020.GameData _data;

        public GGJ2020.GameData GetData()
        {
            if (_data == null) {
                throw new Exception("GameData is not loaded!");
            }

            return _data;
        }

        [Button("Reload!")]
        public void LoadFromGData()
        {
            if (GDataApiKey == "" || GDataSpreadsheetId == "") {
                Debug.LogError("Fill SpreadsheetId and ApiKey fields to load");
            }

            Debug.Log("[GameData] Loading!");
            DataSource ds = new DataSource(GDataApiKey, GDataSpreadsheetId);
            EntityLoader loader = new EntityLoader(ds);
            _data = loader.Load(typeof(GGJ2020.GameData));
            Debug.Log("[GameData] Loaded!");

            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
    }
}