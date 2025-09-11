using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        
        
        if ( controller != null)
        {
            Destroy(gameObject);
            controller.PlaySound(collectedClip);
            if ( controller.health < controller.maxhealth)
            {
                controller.changehealth(1);
            }
        }
    }
}
