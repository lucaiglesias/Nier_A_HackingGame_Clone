using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 pointA;
    [SerializeField] Vector3 pointB;

    Vector3 destination;
    [SerializeField] float speed;

    private void Start()
    {
        StartCoroutine(AICoroutine());
    }

    IEnumerator AICoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            destination.x = Random.Range(pointA.x, pointB.x);
            destination.y = Random.Range(pointA.y, pointB.y);
            
            while (Vector3.Distance(transform.position, destination) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            }

        }
    }
}
