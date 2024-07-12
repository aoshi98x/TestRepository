using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartRing : MonoBehaviour
{
    Spawner spawner;
    private void Start() {

        spawner = FindAnyObjectByType<Spawner>();
    }
    private void OnDisable() {
       spawner.RestartRing(this.gameObject);
    }
}
