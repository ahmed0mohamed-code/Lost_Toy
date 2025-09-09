using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public int maxhealth = 5;
    float currenthealth;
    public float health { get { return currenthealth; } }
    public float speed = 2.5f;
    public float timeInvincible ;
    bool isInvincible;
    float damagecooldown;
    public float healingtimeinvincible;
    float healingtime;
    bool Ishealing;
    Animator animator;
    Vector2 moveDirection = new Vector2(1, 0);
    public GameObject projectileprefab;
    AudioSource audiosource;
    public AudioClip walking;
    public AudioClip projection;
    public AudioClip accident;
    public AudioClip Damage;
    public GameOverHandler gameOverHandler;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currenthealth = maxhealth;
        Camera.main.enabled = true;
        if (Camera.main == null)
        {
            Debug.LogError("No main camera found!");
        }
        audiosource = GetComponent<AudioSource>(); 
    }



    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }

        animator.SetFloat("Look X", moveDirection.x);
        animator.SetFloat("Look Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude); 

        if (isInvincible)
        {
            damagecooldown -= Time.deltaTime;
            if (damagecooldown < 0 )
            {
                isInvincible = false;
            }
        }
        if (Ishealing)
        {
            healingtime -= Time.deltaTime;
            if ( healingtime < 0 )
            {
                Ishealing = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
        if (move != Vector2.zero && !audiosource.isPlaying)
        {
            audiosource.PlayOneShot(walking);
        }


    }
    public void changehealth (float amount)
    {
        
        if (amount == -5)
        {
            audiosource.PlayOneShot(accident);
        }
        else if (amount < 0 )
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damagecooldown = timeInvincible;
            animator.SetTrigger("Hit");
            audiosource.PlayOneShot(Damage);
        }
        if (amount == 0.5)
        {
            if (Ishealing)
            {
                return;
            }
            Ishealing = true;
            healingtime = healingtimeinvincible;
        }
        currenthealth = Mathf.Clamp(currenthealth + amount, 0, maxhealth);
        UIHandler.Instance.SetHealthValue(currenthealth /(float) maxhealth);

        if (currenthealth <= 0 )
        {
            gameOverHandler.ShowGameOver();
        }
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectileprefab, rigidbody2d.position , Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.launch(moveDirection, 300);
        animator.SetTrigger("Launch");
        audiosource.PlayOneShot(projection);
    }

    public void PlaySound(AudioClip clip)
    {
        audiosource.PlayOneShot(clip);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
