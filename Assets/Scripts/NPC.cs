using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPC : MonoBehaviour
{
    public WinnerHandler winnerHadler;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null) // ✅ only trigger if Player touches
        {
            winnerHadler.showWinnerScreen(); // <-- use a "winner" function
        }
    }
}
