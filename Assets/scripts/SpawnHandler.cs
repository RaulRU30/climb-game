using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform teleport;

    private GameObject spawnedPlayer;

    void Start()
    {
        if (spawnPoint != null)
        {
            // Instancia el personaje en la posición y rotación del punto de spawn
            Vector3 adjustedPosition = spawnPoint.transform.position + new Vector3(0, 10, 0);
            spawnedPlayer = Instantiate(playerPrefab, adjustedPosition, spawnPoint.transform.rotation);
        }

    }


    void Update()
    {
        if (spawnedPlayer != null && Input.GetKeyDown(KeyCode.P))
        {
            spawnedPlayer.transform.position = teleport.position;
        }

    }
}
