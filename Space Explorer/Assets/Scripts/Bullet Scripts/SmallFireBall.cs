using UnityEngine;

public class SmallFireBall : MonoBehaviour
{
    public float fireballSpeed;

    private Rigidbody2D myBody;

    private float maxY;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxY = screenBounds.y;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move the fireball
        myBody.linearVelocity = new Vector2(0, fireballSpeed);
        OnBecameInvisible();
    }

    private void OnBecameInvisible()
    {
        if (transform.position.y > maxY)
        {
            Destroy(gameObject);
        }
    }
}
