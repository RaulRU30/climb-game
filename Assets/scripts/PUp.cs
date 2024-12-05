using UnityEngine;

public class PUp : MonoBehaviour
{
    [SerializeField] private string powerUpType = "Jump"; // Tipo de Power-Up (Jump o Speed)
    private PUpManager powerUpManager;

    void Start()
    {
        // Busca al Power-Up Manager en la escena
        powerUpManager = FindObjectOfType<PUpManager>();
        if (powerUpManager == null)
        {
            Debug.LogError("No se encontró PowerUpManager en la escena.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && powerUpManager != null)
        {
            Debug.Log($"Jugador interactuó con el Power-Up: {powerUpType}");
            powerUpManager.TriggerPowerUp(gameObject, powerUpType);
        }
    }
}
