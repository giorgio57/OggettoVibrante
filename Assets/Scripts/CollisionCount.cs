using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCount : MonoBehaviour
{
    public static string eventstring = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "FPSController")
        {
            CollisionDetection.NumCollisions += 1;
            eventstring = ("Hit the " + gameObject.ToString());
            Debug.Log(eventstring);
        }
    }

}
