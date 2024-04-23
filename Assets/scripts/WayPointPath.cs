using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointPath : MonoBehaviour {

    [HideInInspector]
    public List<Vector3> WayPoints;



    // Start is called before the first frame update
    void Start()
    {
        refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        refresh();
        Gizmos.color = Color.black;
        for(int i = 0; i < WayPoints.Count; i++)
        {
            Gizmos.DrawSphere(WayPoints[1], 0.1f);
            if (i == 0)
                Gizmos.DrawLine(WayPoints[i], WayPoints[WayPoints.Count-1]);
            else
                Gizmos.DrawLine(WayPoints[i], WayPoints[i- 1]);
        }

    }
    void OnTransformChildrenChanged()
    {
        refresh();

    }

    public void refresh()
    {
        if (WayPoints == null)
            WayPoints = new List<Vector3>();
        WayPoints.Clear();

        foreach (var childTransform in GetComponentsInChildren<Transform>())
        {
            if (transform == childTransform)
                continue;
            WayPoints.Add(childTransform.position);
        }
    }
}
