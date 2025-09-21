using UnityEngine;

public class ZDamage : MonoBehaviour
{
    public float Timer = 10f;
    float Zdamage;
    public GameObject Z;

    private void Start()
    {
        Zdamage = Timer;
    }

    private void Update()
    {
        Zdamage -= Time.deltaTime;

        if (Zdamage <= 0)
        {
            Zdamage = Timer;
            if (Z.activeInHierarchy)
            {
                Z.SetActive(false);
            }
            else
            {
                Z.SetActive(true);
            }
        }
    }





}
