using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMaker : MonoBehaviour
{
    public GameObject rigidbodyPrefab;
    GameObject Ball;

    public int RandomTorque = 15;

    public float MakeBallTimer = 1.5f;

    public int DestroyBallTimer = 100;

    void Start()
    {
        InvokeRepeating("MakeBall", 0.5f, MakeBallTimer);
    }
    
    void MakeBall()
    {
        Ball = Instantiate(rigidbodyPrefab, transform.position, transform.rotation) as GameObject;
        Ball.GetComponent<Rigidbody>().AddTorque(Random.Range(-RandomTorque, RandomTorque), Random.Range(-RandomTorque, RandomTorque), 0);
        Ball.transform.parent = transform;
        Destroy(Ball, DestroyBallTimer);
        
    }
}
