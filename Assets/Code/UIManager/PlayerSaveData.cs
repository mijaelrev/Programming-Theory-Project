using System;
using UnityEngine;

namespace Code.UIManager
{
    public class PlayerSaveData : MonoBehaviour
    {
        public UnityEngine.Events.UnityEvent<float> onUpdateScore;
        public UnityEngine.Events.UnityEvent<string> onUpdateName;

        //public static PlayerSaveData Instance;
        public string playerName;

        public float maxScore;

        private MainMenu _mainMenu;
        internal void Configure(MainMenu mainMenu) => _mainMenu = mainMenu;

        private void Awake()
        {

            LoadDataPersistence();
            onUpdateScore.AddListener(UpdateMaxScore);
            onUpdateName.AddListener(UpdateCurrentName);
        }

        private void UpdateCurrentName(string currentName) => playerName = currentName;

        internal void UpdateMaxScore(float newMaxScore)
        {
            if (maxScore < newMaxScore)
            {
                maxScore = newMaxScore;
            }
        }

        [Serializable]
        public class SaveData
        {
            public string name;
            public float maxScore;
        }

        internal void SaveDataPersistence()
        {
            SaveData data = new SaveData();
            data.name = playerName;
            data.maxScore = maxScore;

            string json = JsonUtility.ToJson(data);

            System.IO.File.WriteAllText(Application.persistentDataPath + "/DontFall.json", json);
            Debug.Log("Data is saved");
        }
        internal void LoadDataPersistence()
        {
            string path = Application.persistentDataPath + "/DontFall.json";
            if (System.IO.File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                playerName = data.name;
                maxScore = data.maxScore;
                Debug.Log("Data is load");
            }
        }
    }
}