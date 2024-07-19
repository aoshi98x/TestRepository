using System;
using TMPro;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
    public string userName;
    public TextMeshProUGUI welcomeMsm;
    public TMP_InputField inputText;
    int scorePoint;
    void Start()
    {
        if(PlayerPrefs.HasKey("user"))
        {
            userName = PlayerPrefs.GetString("user");
        }
        else
        {
            userName = "User";
        }
    }

    void Update()
    {
        if(PlayerPrefs.HasKey("user"))
        {
            userName = PlayerPrefs.GetString("user");
            welcomeMsm.text = "Welcome "+ userName;
        }
        else
        {
            userName = "User";
            welcomeMsm.text = "Welcome "+ userName;
        }
    }

    public void SaveUserName()
    {
        PlayerPrefs.SetString("user", inputText.text);
    }
    public void DeleteUserName()
    {
        PlayerPrefs.DeleteKey("user");
    }
    public void SaveScore(string userNamePoints)
    {
        PlayerPrefs.SetString(userNamePoints, Convert.ToString(scorePoint));
    }
}
