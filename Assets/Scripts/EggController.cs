using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EggController : MonoBehaviour
{
    public List<GameObject> nests = new List<GameObject>(); 
    public int points;
    [SerializeField]TextMeshProUGUI textPoints;
    public AudioClip gameMusic;

    void Start()
    {
        AudioManager.Instance.PlayMusic(gameMusic);

        for (int i = 0; i < transform.childCount; i++)
        {
            nests.Add(transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        textPoints.text = "Points: " + points;
    }
}
