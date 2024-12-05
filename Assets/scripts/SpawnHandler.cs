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
        SpawnPlayerAtStart();
    }

    private void SpawnPlayerAtStart()
    {
        if (spawnPoint != null)
        {
            // Instancia el personaje en la posición y rotación del punto de spawn
            Vector3 adjustedPosition = spawnPoint.transform.position + new Vector3(0, 10, 0);
            spawnedPlayer = Instantiate(playerPrefab, adjustedPosition, spawnPoint.transform.rotation);
        }
        else
        {
            Debug.LogError("El punto de spawn no está asignado.");
        }
    }

    void Update()
    {
        if (spawnedPlayer != null && Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Teleportando jugador al punto de teletransporte.");
            spawnedPlayer.transform.position = teleport.position;
        }
    }

    public void TeleportToSpawnPoint() // Teletransportar al jugador cuando se acabe el tiempo
    {
        if (spawnedPlayer != null)
        {
            // Eliminar el jugador existente
            Debug.Log("Destruyendo el jugador existente antes de teletransportarlo.");
            Destroy(spawnedPlayer);
        }

        if (spawnPoint != null)
        {
            // Instanciar un nuevo jugador en el punto de spawn
            Vector3 adjustedPosition = spawnPoint.transform.position + new Vector3(0, 10, 0);
            spawnedPlayer = Instantiate(playerPrefab, adjustedPosition, spawnPoint.transform.rotation);
            Debug.Log("Jugador teletransportado al punto de spawn.");
        }
        else
        {
            Debug.LogError("El punto de spawn no está asignado.");
        }
    }
}
