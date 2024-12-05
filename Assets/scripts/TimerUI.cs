using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private float initialTime = 60f; // Tiempo inicial para reiniciar
    [SerializeField] private TextMeshProUGUI timerText; // Referencia al texto del temporizador
    [SerializeField] private SpawnHandler spawnHandler; // Referencia al SpawnHandler para teletransportar al jugador

    private float timeRemaining;
    private bool isTimerRunning = true;

    void Start()
    {
        // Busca automáticamente el SpawnHandler si no está asignado
        if (spawnHandler == null)
        {
            spawnHandler = FindObjectOfType<SpawnHandler>();
            if (spawnHandler == null)
            {
                Debug.LogError("No se encontró un SpawnHandler en la escena.");
                return;
            }
        }

        // Inicializa el tiempo restante y actualiza la interfaz
        timeRemaining = initialTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                // Disminuye el tiempo restante
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                // Detiene el temporizador y ejecuta la lógica de finalización
                isTimerRunning = false;
                timeRemaining = 0;
                UpdateTimerDisplay();
                OnTimerEnd();
            }
        }
    }

    private void UpdateTimerDisplay()
    {
        // Comprueba si el texto del temporizador está asignado
        if (timerText == null)
        {
            Debug.LogWarning("El objeto TextMeshProUGUI no está asignado.");
            return;
        }

        // Convierte el tiempo restante a minutos y segundos
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Actualiza el texto en pantalla
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnTimerEnd()
    {
        Debug.Log("El tiempo se ha agotado.");
        
        // Llama al método del SpawnHandler para teletransportar al jugador
        if (spawnHandler != null)
        {
            spawnHandler.TeleportToSpawnPoint();
        }
        else
        {
            Debug.LogWarning("SpawnHandler no está asignado. No se puede teletransportar al jugador.");
        }

        // Reinicia el temporizador
        ResetTimer();
    }

    public void ResetTimer()
    {
        // Restablece el tiempo inicial y reactiva el temporizador
        timeRemaining = initialTime;
        isTimerRunning = true;
        UpdateTimerDisplay();
    }
}
