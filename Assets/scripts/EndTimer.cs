using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Endtimer : MonoBehaviour
{
    public bool timerOn;
    public float timeRemaining;
    public TextMeshPro timerText;
    public BoxCollider2D trigger;

    // Start is called before the first frame update
    void Start()
        {
            timerOn = true;
            if (PlayerPrefs.HasKey("timeValue"))
            {
                timeRemaining = PlayerPrefs.GetFloat("timeValue");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (timeRemaining >= 0 && timerOn)
            {
                timeRemaining += Time.deltaTime;
                PlayerPrefs.SetFloat("timeValue", timeRemaining);
                updateTimer(timeRemaining);

            }
            else
            {
                timerOn = false;
            }
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (trigger != null)
        {
            stopTimer();
        }
    }
    void updateTimer(float timer)
        {
            timer += 1;
            float min = Mathf.FloorToInt(timer / 60);
            float sec = Mathf.FloorToInt(timer % 60);

            timerText.text = string.Format("{00} : {1:00}", min, sec);
        }  
        public void stopTimer()
        {
            timerOn = false;
        }
    public void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("timeValue");
    }
}
  
