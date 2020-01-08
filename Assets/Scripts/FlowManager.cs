using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoBehaviour
{
    public float createPeriod = 10f;
    public float randomTime = 10f;
    public GameObject flowPrefab;
    public GameObject ballPrefab;
    public GameObject barPrefab;
    void Start()
    {
        StartCoroutine(CreatorFlow());
        StartCoroutine(CreatorBall());
        StartCoroutine(CreatorBar());
    }

    IEnumerator CreatorFlow(){
        while(true){
            Instantiate(flowPrefab, transform);
            yield return new WaitForSeconds(createPeriod + Random.Range(0, randomTime));
        }
    }

    IEnumerator CreatorBall(){
        while(true){
            Instantiate(ballPrefab, transform);
            yield return new WaitForSeconds(createPeriod + Random.Range(0, randomTime));
        }
    }

    IEnumerator CreatorBar(){
        while(true){
            Instantiate(barPrefab, transform);
            yield return new WaitForSeconds(createPeriod + Random.Range(0, randomTime));
        }
    }

}
