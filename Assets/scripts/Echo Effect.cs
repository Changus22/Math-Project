using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{ 
    public float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject echo;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
            Destroy(instance, 0.5f);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
