using UnityEngine;

public class Despawn : MonoBehaviour
{
    public EdgeCollider2D hitBox;
    public float TimeLeft = 5;
    public bool TimerOn = false;

    void Start()
    {
       TimerOn = true;
    }

    void Update()
    {
        if(TimerOn)
        {
            if (TimeLeft <= 0)
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
            }
            else
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            if(TimeLeft == 0)
            {
                hitBox.isTrigger = true;
            }
        }
    }
    void updateTimer(float timer)
    {
        timer += 1;
        float min = Mathf.FloorToInt(timer / 60);
        float sec = Mathf.FloorToInt(timer % 60);

    }
}
