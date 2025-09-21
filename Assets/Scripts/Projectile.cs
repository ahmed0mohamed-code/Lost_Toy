using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;



public class Projectile : MonoBehaviour
{
    Rigidbody2D projectile;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        projectile = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    public void launch(Vector2 direction, float force)
    {
        projectile.AddForce(direction * force);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy2 enemy2 = other.GetComponent<Enemy2>();
        if(enemy2 != null)
        {
            enemy2.Fixed();
        }

        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.Fix(); 
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }


}
