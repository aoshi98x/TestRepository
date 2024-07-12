using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ringPrefab;
    [SerializeField] Transform[] points;
    public List<GameObject> rings;

    void Start()
    {
        for (int i = 0; i < points.Length; i++)
        {
            GameObject ring;
            ring = Instantiate (ringPrefab, points[i].position, Quaternion.identity);
            rings.Add(ring);
        }
    }
    public void RestartRing(GameObject ring)
    {
        StartCoroutine(Restart(ring));
    }

    public IEnumerator Restart(GameObject ring)
    {
        int time = Random.Range(1,6);
        yield return new WaitForSeconds(time);
        ring.SetActive(true);
    }
    
}
