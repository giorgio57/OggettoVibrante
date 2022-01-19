using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [Range(0f, 2f)]
    public float Intensity;

    Transform _target;
    Vector3 _initialPos;

    void Start()
    {
        _target = GetComponent<Transform>();
        _initialPos = _target.localPosition;
    }

    float _pendingShakeDuration = 0f;

    public void Shake(float duration)
    {
        _pendingShakeDuration += duration;
        //Debug.Log("Shake");

    }

    
    bool _isShaking = false;

    public void Freeze()
    {
        _pendingShakeDuration = 0f;
        _target.localPosition = _initialPos;
        _isShaking = false;

    }


    void Update()
    {
        if(_pendingShakeDuration > 0 && !_isShaking)
        {
            StartCoroutine(DoShake());
        }
    }

    IEnumerator DoShake()
    {
        _isShaking = true;

        var startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + _pendingShakeDuration)
        {
            var randomPoint = new Vector3(Random.Range(-0.06f,0.06f)*Intensity, 0f, Random.Range(-0.06f, 0.06f)*Intensity);
            _target.localPosition = _initialPos + randomPoint;
            yield return null;


        }



        _pendingShakeDuration = 0f;
        _target.localPosition = _initialPos;
        _isShaking = false;
    }


}
