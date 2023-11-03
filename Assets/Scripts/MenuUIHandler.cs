using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField usernameField;

    private void Start()
    {
        usernameField.onValueChanged.AddListener(OnUsernameInputValueChanged);

        if (SessionData.Instance != null)
        {
            SetBestScore();
        }
    }

    public void OnUsernameInputValueChanged (string value)
    {
        SessionData.Instance.username = value;
    }

    public void SetBestScore()
    {
        if (SessionData.Instance.bestScoreUser != "")
        {
            bestScoreText.text = $"Best Score: {SessionData.Instance.bestScoreUser} - {SessionData.Instance.bestScore}";
        }
        else
        {
            bestScoreText.text = "Best Score: " + SessionData.Instance.bestScore;
        }
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
