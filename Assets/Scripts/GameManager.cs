using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int highScore;
    public string highName;
    public string name;
    public TextMeshProUGUI inputNameText;
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveInfo
    {
        public string lastPlayerName;
        public string highPlayerName;
        public int highScore;
    }

    public void SaveGameInfo()
    {
        SaveInfo data = new SaveInfo();
        if (inputNameText != null) {
            name = inputNameText.text;
                }
        data.lastPlayerName = name;
        data.highPlayerName = highName;
        data.highScore = highScore;
        ;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/playerinfo.json", json);
    }

    public void LoadGameInfo()
    {
        string path = Application.persistentDataPath + "/playerinfo.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveInfo data = JsonUtility.FromJson<SaveInfo>(json);

            name = data.lastPlayerName;
            highName = data.highPlayerName;
            highScore = data.highScore;
        }
    }
}
