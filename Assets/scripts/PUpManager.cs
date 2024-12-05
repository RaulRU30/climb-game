using System.Collections;
using UnityEngine;
using Invector.vCharacterController;

public class PUpManager : MonoBehaviour
{
    [SerializeField] private float powerUpDuration = 5f; // Duración del efecto
    private GameObject player; // Referencia al jugador
    private bool isPowerUpActive = false; // Estado del Power-Up

    void Start()
    {
        StartCoroutine(WaitAndFindPlayer());
    }

    private IEnumerator WaitAndFindPlayer()
    {
        yield return new WaitForSeconds(1f);
        FindPlayer();
    }

    private void FindPlayer()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("No se encontró al jugador en la escena.");
        }
    }

    public void TriggerPowerUp(GameObject powerUpObject, string powerUpType)
    {
        if (isPowerUpActive || player == null)
        {
            Debug.LogWarning("No se puede activar un nuevo Power-Up. Ya hay uno activo o no se encontró al jugador.");
            return;
        }

        Debug.Log($"Activando Power-Up: {powerUpType}");
        isPowerUpActive = true;

        // Aplica el efecto según el tipo
        ApplyEffectToPlayer(powerUpType);

        // Destruye el objeto del Power-Up
        Destroy(powerUpObject.transform.parent.gameObject);

        // Inicia la duración del Power-Up
        StartCoroutine(PowerUpEffect(powerUpType));
    }

    private IEnumerator PowerUpEffect(string powerUpType)
    {
        yield return new WaitForSeconds(powerUpDuration);

        // Finaliza el efecto
        RemoveEffectFromPlayer(powerUpType);
        isPowerUpActive = false;

        Debug.Log("Power-Up terminado.");
    }

    private void ApplyEffectToPlayer(string powerUpType)
    {
        vThirdPersonController playerController = player.GetComponent<vThirdPersonController>();

        if (playerController == null)
        {
            Debug.LogWarning("No se encontró el controlador del jugador.");
            return;
        }

        switch (powerUpType)
        {
            case "Speed":
                playerController.moveSpeed *= 2; // Duplica la velocidad
                break;
            case "Jump":
                playerController.jumpHeight *= 3; // Triplica la altura del salto
                break;
            default:
                Debug.LogWarning($"Tipo de Power-Up desconocido: {powerUpType}");
                break;
        }
    }

    private void RemoveEffectFromPlayer(string powerUpType)
    {
        vThirdPersonController playerController = player.GetComponent<vThirdPersonController>();

        if (playerController == null)
        {
            Debug.LogWarning("No se encontró el controlador del jugador.");
            return;
        }

        switch (powerUpType)
        {
            case "Speed":
                playerController.moveSpeed /= 2; // Restaura la velocidad original
                break;
            case "Jump":
                playerController.jumpHeight /= 3; // Restaura la altura del salto
                break;
            default:
                Debug.LogWarning($"Tipo de Power-Up desconocido: {powerUpType}");
                break;
        }
    }
}
