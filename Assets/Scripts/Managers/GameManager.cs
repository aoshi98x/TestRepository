using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public bool isPaused;
    public bool cachedRing;
    

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void CheckPause()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            Time.timeScale=0;
        }
        else{

            Time.timeScale=1;
        }
    }

    public void SceneChange(string name)
    {
        isPaused = false;
        SceneManager.LoadScene(name);
        
    }
}
