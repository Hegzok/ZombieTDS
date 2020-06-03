using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText, youWonText;
    [SerializeField] private float timer;

    private void Update()
    {
        DecrementTimer();
    }

    private void DecrementTimer()
    {
        int seconds = (int)(timer % 60);
        int minutes = (int)(timer / 60) % 60;

        string timerCalculated = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            timerText.text = timerCalculated;
        }
        else
        {
            Time.timeScale = 0f;
            youWonText.enabled = true;
            EventsManager.CallOnGameWon();
        }

    }

}
