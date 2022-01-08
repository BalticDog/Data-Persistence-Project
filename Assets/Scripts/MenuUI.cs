using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI hightscoreText;
    public TMP_InputField nameText;


    private void Start()
    {

        GameManager.Instance.LoadGameInfo();
        nameText.text = GameManager.Instance.name;

        if (GameManager.Instance.highScore < 1) 
        {
            hightscoreText.text = "There is no highscore yet.";
        }
        else
        {
            string highName = GameManager.Instance.highName;
            int highScore = GameManager.Instance.highScore;
            hightscoreText.text = "<b>Best Score:  </b> \n <color=#A8A8F6FF>"+ highName + " - "+ highScore +"</color>";
        }
    }




    public void StartNew()
    {
        GameManager.Instance.SaveGameInfo();
        SceneManager.LoadScene(1);
        
    }

    public void Exit()
    {

        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                        Application.Quit(); // original code to quit Unity player
        #endif

    }
}
