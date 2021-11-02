using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    List<Vector3> camPositions = new List<Vector3>();
    public GameObject Building; 

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform pos in Building.GetComponentInChildren<Transform>())
        {
            camPositions.Add(pos.position + new Vector3(0,5,0));
        }

        foreach (Vector3 v3 in camPositions)
        {
            Debug.Log(v3);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            Vector3 newpos = camPositions[ Random.Range(0, camPositions.Count)];//get new random position
                                                                                //Teleport
                                                                                //transform.position = newpos;

            //Lerp
            StartCoroutine(StartLerp(this.transform.position, newpos, false));
            //
        }
    }

    IEnumerator StartLerp(Vector3 _startPos, Vector3 _endPos, bool _repeat)
    {
        yield return this.GetComponent<Lerper>().StartLerp(_startPos, _endPos, _repeat);
    }
}
