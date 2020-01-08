using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallFlow : MonoBehaviour
{
    public float flowSpeed = 0.005f;
    public float posToCreate = 2;
    public float posToRemove = -2;

    public float posHeightMax = 0.4f;
    public float posHeightMin = 0.2f;

    void Start()
    {
        transform.position = new Vector3(posToCreate, Random.Range(posHeightMin, posHeightMax), 0);
        transform.DOLocalMoveY(Random.Range(-0.1f, 0.1f), 2.07f).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-flowSpeed, 0, 0);
        if(transform.position.x < posToRemove){
            Destroy(gameObject);
        }
    }
}
