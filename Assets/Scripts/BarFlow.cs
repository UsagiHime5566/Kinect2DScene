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

    void Start()
    {
        transform.position = new Vector3(posToCreate, Random.Range(posHeightMin, posHeightMax), 0);
    }

    void Update()
    {
        transform.Translate(-flowSpeed, 0, 0);
        if(transform.position.x < posToRemove){
            Destroy(gameObject);
        }
    }
}
