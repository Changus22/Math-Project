using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class StartTimer : MonoBehaviour
{
    public bool timerOn;
    public float timeRemaining;
    public TextMeshPro timerText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startTimer()
    {
        timerOn = true;
    }
    public void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("timeValue");
    }
}
