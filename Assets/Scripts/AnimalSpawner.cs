using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> animalsPrefabs = new List<GameObject>();
    [SerializeField] List<Transform> points = new List<Transform>();
    int animalIndex, posIndex;
    

    [ContextMenu ("Poner Animalito")]
    void SpawnAnimal()
    {
        animalIndex = Random.Range(0, animalsPrefabs.Count);
        posIndex = Random.Range(0, points.Count);
        Quaternion newAngles = Quaternion.Euler(0,180,0);

        Instantiate(animalsPrefabs[animalIndex], points[posIndex].position, newAngles);
    }
}
