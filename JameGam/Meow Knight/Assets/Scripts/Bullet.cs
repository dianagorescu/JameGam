using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 50;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(hitInfo.tag == "Player")
        {
            return;
        }
        if(enemy != null)
        {
            Debug.Log("EnemyHit");
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
