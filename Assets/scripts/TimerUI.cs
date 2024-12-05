using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 60f;
    [SerializeField] private TextMeshProUGUI timerText;
    private bool isTimerRunning = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Resta tiempo
                UpdateTimerDisplay();
            }
            else
            {
                isTimerRunning = false;
                timeRemaining = 0;
                UpdateTimerDisplay();
                OnTimerEnd();
            }
        }

    }

    private void UpdateTimerDisplay()
    {
        // Convierte el tiempo a minutos y segundos
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Actualiza el texto del timer
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnTimerEnd()
    {
        Debug.Log("El tiempo se ha agotado.");
        // Aquí puedes poner la lógica al final del timer
    }


}
