using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class BasketMovment : MonoBehaviour
{
    public WayPointPath Path;
    public float Speed = 3f;
    public AnimationCurve Animation;
    protected int currentWPIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentWPIndex = 0;
        transform.position = Path.WayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        var prevTarget = (currentWPIndex == 0) ? Path.WayPoints[Path.WayPoints.Count - 1] : Path.WayPoints[currentWPIndex - 1];
        var currTarget =  Path.WayPoints[currentWPIndex];
        var toTraget  = currTarget - transform.position;
        var toGo  = toTraget.normalized * Speed * Time.deltaTime * Animation.Evaluate(1 - (toTraget.magnitude / Vector3.Distance(prevTarget,currTarget)));

        if (toTraget.magnitude < 0.01f || toGo.magnitude > toTraget.magnitude)
        {
            currentWPIndex = (currentWPIndex + 1) % Path.WayPoints.Count;
            toGo = toTraget;
        }
        transform.position += toGo;
    }
}
