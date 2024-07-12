using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]GameObject PauseUI;
    void Update()
    {
        if (GameManager.Instance.isPaused)
        {
            PauseUI.SetActive(true);
        }
        else
        {
            PauseUI.SetActive(false);   
        }
    }
    public void ResetState(int index)
    {
        transform.GetChild(index).gameObject.SetActive(false);
        GameManager.Instance.CheckPause();
    }
}
