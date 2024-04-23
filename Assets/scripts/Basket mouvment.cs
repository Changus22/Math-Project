using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Basketmouvment : MonoBehaviour
{
    public Transform Basketmouvement;
    public Transform startPoint;
    public Transform middles;
    public Transform endPoint;
    public float speed = 1.5f;

    int direction = 1;
    private void OnDrawGizmos()
    {
        if (Basketmouvement != null && startPoint != null && middles!=null && endPoint != null)
        {
            Gizmos.DrawLine(middles.transform.position, startPoint.position);
            Gizmos.DrawLine(Basketmouvement.transform.position, middles.position);
            Gizmos.DrawLine(middles.transform.position, endPoint.position);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = currentMovementTarget();

        Basketmouvement.position = Vector2.Lerp(Basketmouvement.position, target, speed * Time.deltaTime);
        
        float distace = (target - (Vector2)Basketmouvement.position).magnitude;
       
        if (distace <= 0.1f)
        {
            direction *= -1;
        }
    }
    Vector2 currentMovementTarget()
    {
            if (direction == 1)
            {
                return startPoint.position;
            }
            if (direction == -1)
            {
                return middles.position;
            }
            else
            {
                return endPoint.position;
            }
        }
    }