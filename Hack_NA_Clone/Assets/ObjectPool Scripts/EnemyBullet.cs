using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //    [SerializeField] GameObject player;
    //    // Update is called once per frame

    //    Vector3 playerPosition;
    //    void Update()
    //    {
    //        playerPosition = player.transform.position;
    //        transform.position += playerPosition * transform.up * speed * Time.deltaTime;
    //    }
    //

    [SerializeField] float speed = 0.5f;
    [SerializeField] SpriteRenderer spriteRenderer;


    public void Reset()
    {
        spriteRenderer.color = Color.red;

    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.yellow, 0.1f * Time.deltaTime);
        //Destroy(gameObject, 20f);
    }
}
