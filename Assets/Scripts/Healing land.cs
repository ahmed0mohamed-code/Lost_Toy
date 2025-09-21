using Unity.VisualScripting;
using UnityEngine;

public class Healingland : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null && controller.health < controller.maxhealth )
        {
            controller.changehealth((float)0.5);
        }
            
        
    }
}
