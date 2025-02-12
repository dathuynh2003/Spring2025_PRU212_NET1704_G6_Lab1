using UnityEngine;

public class Plane : MonoBehaviour
{
    public float planeSpeed;
    public float shootCooldown;

    private Rigidbody2D myBody;

    [SerializeField]
    private GameObject bullet;
    private float lastShotime;

    private GameObject flame;

    private void Awake()
    {
        // Get the Rigidbody2D component attached to the plane
        myBody = GetComponent<Rigidbody2D>();

        flame = transform.GetChild(0).gameObject;
        flame.SetActive(false);
    }

    void Start()
    {

    }

    void Update()
    {
        PlaneMovement();
        Shoot();
    }

    private void PlaneMovement()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // If the player is moving up, turn on flame
        // Else turn off flame
        if (moveVertical > 0)
        {
            ToggleFlame(true);
        }
        else
        {
            ToggleFlame(false);
        }

        // Move the plane
        myBody.linearVelocity = movement * planeSpeed;
    }

    private void Shoot()
    {
        // Get the Renderer component attached to the plane
        Renderer renderer = GetComponent<Renderer>();
        // Calculate the height of the plane
        float planeHeight = renderer.bounds.size.y;

        var bulletPos = new Vector3(transform.position.x, transform.position.y + (planeHeight / 2) + 0.1f, 0);
        if (Input.GetMouseButton(0) && Time.time >= lastShotime + shootCooldown)
        {
            Instantiate(bullet, bulletPos, Quaternion.Euler(0, 0, 180));
            lastShotime = Time.time;
        }
    }

    private void ToggleFlame(bool isActive)
    {
        if (flame.activeSelf != isActive)
        {
            flame.SetActive(isActive);
            //Debug.Log("Flame is active: " + isActive);
        }
    }
}
