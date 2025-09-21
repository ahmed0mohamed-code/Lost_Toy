using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed;
    public Rigidbody2D Enemy;
    public bool vertical;
    public float changetime = 3f;
    private float timer;
    int direction = 1;
    Animator animator;
    bool broken = true;
    AudioSource audioSource;
    public ParticleSystem smoke;
    public int target = 3;
    int current;

    private void Start()
    {
        Enemy = GetComponent<Rigidbody2D>();
        timer = changetime;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = changetime;
            direction = -direction;
        }
    }

    private void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }

        Vector2 position = Enemy.position;

        if (vertical)
        {
            position.y = position.y + speed * direction * Time.deltaTime;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
        }
        else
        {
            position.x = position.x + speed * direction * Time.deltaTime;
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("MoveX", direction);
        }

        Enemy.MovePosition(position);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.changehealth(-5);
        }
    }

    public void Fixed()
    {
        current ++;

        if (current >= target)
        {
            broken = false;
            audioSource.Stop();
            smoke.Stop();
            Enemy.simulated = false;
            animator.SetTrigger("Fixed");
        }
    }
}
