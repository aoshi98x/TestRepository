using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    public void LoseGame(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
