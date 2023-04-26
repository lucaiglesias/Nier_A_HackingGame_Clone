using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject enemyBulletPrefab;
    
    [SerializeField] Vector3 pointA;
    [SerializeField] Vector3 pointB;
    [SerializeField] float speed = 2f;
    [SerializeField] int BulletStorm;

    Vector3 destination;
    //GameObject bulletObject = BulletPool.Instance.GetPoolObject();

    private void Start()
    {
        StartCoroutine(AICoroutine());
    }

    //private void Update()
    //{
    //    if (bulletObject.transform.position.x < -10f || bulletObject.transform.position.x > 10f || bulletObject.transform.position.y < -6f || bulletObject.transform.position.y > 6f)
    //    {
    //        bulletObject.SetActive(false);
    //    }
    //}

    IEnumerator AICoroutine()
    {
        while (true)
        {
            //Enemy movement to random places
            yield return new WaitForSeconds(2f);
            destination.x = Random.Range(pointA.x, pointB.x);
            destination.y = Random.Range(pointA.y, pointB.y);
            
            while (Vector3.Distance(transform.position, destination) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(0.5f);
            
            for (int j= 0; j < 3; j++)
            {
                float angle = j*30f;

                for(int i = 0; i < BulletStorm; i++)
                {
                    //Instantiate(enemyBulletPrefab, transform.position, Quaternion.Euler(0, 0, angle));

                    GameObject bulletObject = BulletPool.Instance.GetPoolObject();
                    bulletObject.transform.position = transform.position;
                    bulletObject.transform.rotation = Quaternion.Euler(0, 0, angle);
                    bulletObject.GetComponent<EnemyBullet>().Reset();
                    bulletObject.SetActive(true);
                    angle += 360f / BulletStorm;
                    if (bulletObject.transform.position.x < -10f || bulletObject.transform.position.x > 10f || bulletObject.transform.position.y < -6f || bulletObject.transform.position.y > 6f)
                    {
                        bulletObject.SetActive(false);
                    }
                }
                yield return new WaitForSeconds(0.15f);
            }

        }
    }
}
