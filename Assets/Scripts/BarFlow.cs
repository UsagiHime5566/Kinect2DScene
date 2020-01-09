using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarFlow : MonoBehaviour
{
    public float flowSpeed = 0.001f;
    public float posToCreate = 2;
    public float posToRemove = -2;

    public float posHeightMax = 0.4f;
    public float posHeightMin = 0.0f;
    public float StartYPos = -1.5f;
    public float raiseSpeed = 0.001f;

    void Start()
    {
        transform.position = new Vector3(posToCreate, StartYPos, 0.5f);
    }

    void Update()
    {
        transform.Translate(-flowSpeed, raiseSpeed, 0);
        if(transform.position.x < posToRemove){
            Destroy(gameObject);
        }
    }
}
