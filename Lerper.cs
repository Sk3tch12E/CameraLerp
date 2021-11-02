using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerper : MonoBehaviour
{
    public GameObject gb;
    public Vector3 startPos, endPos;
    public bool repeatable;
    public float speed = 1.0f;

    float startTime, totalDistance;

    // Start is called before the first frame update
    public IEnumerator StartLerp(Vector3 _startPos, Vector3 _endPos, bool _repeat)
    {
        Debug.Log("a");

        startPos = _startPos;
        endPos = _endPos;
        startTime = Time.time;
        totalDistance = Vector3.Distance(startPos, endPos);

        if (_repeat)
        {
            yield return Lerp(startPos, endPos, 0.5f);
            yield return Lerp(endPos, startPos, 0.5f);
        }
        else
        {
            yield return Lerp(endPos, startPos, 0.5f);
        }
    }

    private IEnumerator Lerp(Vector3 a, Vector3 b, float time)
    {        
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
           
            i += Time.deltaTime * rate;

            gb.transform.position = Vector3.Lerp(b, a, i);
            yield return null;// Vector3.Lerp(a, b, i);
        }
    }
}
