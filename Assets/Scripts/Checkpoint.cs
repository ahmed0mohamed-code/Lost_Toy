using Unity.Cinemachine;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Level2Handler level2handler;
    public GameObject circle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if (controller != null)
        {
            level2handler.Level2();
        }
    }
}
