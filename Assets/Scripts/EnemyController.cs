using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float EnemySpeed;
    public Rigidbody2D Enemy;
    public bool Vertical;
    public float changetime = 3.0f;
    float timer;
    int direction = 1;
    Animator animator;
    bool broken = true;
    AudioSource AudioSource;
    public ParticleSystem smokeEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy = GetComponent<Rigidbody2D>();
        timer = changetime;
        animator = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changetime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }

        Vector2 position = Enemy.position;

        if (Vertical)
        {
            position.y = position.y + EnemySpeed * direction * Time.deltaTime;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + EnemySpeed * direction * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        Enemy.MovePosition(position);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.changehealth(-5);
        }
    }

    public void Fix()
    {
        broken = false;
        Enemy.simulated = false;
        animator.SetTrigger("Fixed");
        AudioSource.Stop();
        smokeEffect.Stop();
    }
}
