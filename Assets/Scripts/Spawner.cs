using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] List<GameObject> pooledItems = new List<GameObject>();
    
    void Start()
    {
       InstancePool(5);
    }

    [ContextMenu ("Iniciar Piscina")]
    void InstancePool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject spawnObj = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            pooledItems.Add(spawnObj);
        }
        foreach (var item in pooledItems)
        {
            item.SetActive(false);
            item.transform.SetParent(this.transform);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < pooledItems.Count; i++)
        {
            if(!pooledItems[i].activeInHierarchy)
            {
                return pooledItems[i];
            }
        }
        return null;

        
    }
}
