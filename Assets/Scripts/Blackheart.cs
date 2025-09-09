using UnityEngine;

public class Blackheart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null )
        {
            controller.changehealth(-4);
            Destroy(gameObject);
        }
    }
}
