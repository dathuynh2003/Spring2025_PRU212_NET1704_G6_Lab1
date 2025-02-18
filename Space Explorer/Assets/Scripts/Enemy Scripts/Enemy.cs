using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{

    public float enemySpeed;
    public float health;
    private float minY;
    private Rigidbody2D myBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject explosionEffect; // Assign explosion effect in Unity
    private AudioManager audioManager;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        if (health <= 0)
        {
            health = Random.Range(3, 6); // random hp if not set in unity
        }

        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        minY = screenBounds.y;

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    void Start()
    {
        myBody.linearVelocity = new Vector2(0f, -enemySpeed);
        
    }

    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //myBody.linearVelocity = new Vector2 (0f, -enemySpeed);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            audioManager.PlaySFX(audioManager.explosion);
            Die();
        }
    }

    void Die()
    {
        // Spawn explosion effect
        if (explosionEffect != null)
        {
            var explosion =  Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 1f); // Destroy explosion effect after 1 second
        }

        Destroy(gameObject); // Destroy enemy
        GameManager.Instance.AddScore(1);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship1") || collision.CompareTag("Ship2") )
        {
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }

            audioManager.PlaySFX(audioManager.gameOver);
            Destroy(collision.gameObject);
            PlayerPrefs.SetString("PlayerScore", GameManager.Instance.scoreText.text);
            SceneManager.LoadScene("GameOverScene");
            
        }
    }

    void OnGUI()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position); // Convert world position to screen
        GUI.Label(new Rect(screenPosition.x, Screen.height - screenPosition.y, 50, 20), "HP: " + health); // Display HP
    }
}
