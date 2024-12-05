using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;

    void Start()
    {
        if (spawnPoint != null)
        {
            // Instancia el personaje en la posición y rotación del punto de spawn
            Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }

    }


    void Update()
    {

    }
}
