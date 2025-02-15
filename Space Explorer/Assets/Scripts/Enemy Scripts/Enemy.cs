using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemySpeed;
    public float health;
    private Rigidbody2D myBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] 
    private GameObject explosionEffect; // Assign explosion effect in Unity

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        if (health <= 0)
        {
            health = Random.Range(3, 6); // random hp if not set in unity
        }
    }
    void Start()
    {
        myBody.linearVelocity = new Vector2(0f, -enemySpeed);
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
            Die();
        }
    }

    void Die()
    {
        // Spawn explosion effect
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); // Destroy enemy
    }

    void OnGUI()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position); // Convert world position to screen
        GUI.Label(new Rect(screenPosition.x, Screen.height - screenPosition.y, 50, 20), "HP: " + health); // Display HP
    }
}
