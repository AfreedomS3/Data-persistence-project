using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SessionData : MonoBehaviour
{
    public static SessionData Instance { get; private set; }

    public string username;
    public int bestScore;
    public string bestScoreUser;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string username;
        public int bestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.username = username;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/gamedata.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/gamedata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScoreUser = data.username;
            bestScore = data.bestScore;
        }
    }
}
