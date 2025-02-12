using UnityEngine;
using UnityEngine.UIElements;

public class PlaneSwitcher : MonoBehaviour
{
    public GameObject spaceShip1;
    public GameObject spaceShip2;

    private GameObject currentShip;
    private Vector3 shipPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shipPosition = new Vector3(0, -3.8f, 0);
        currentShip = Instantiate(spaceShip1, shipPosition, Quaternion.Euler(0, 0, 180));   // Rotate the ship 180 degrees
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right click
        {
            SwapShip();
        }
    }

    private void SwapShip()
    {
        // Get the current ship's position
        shipPosition = currentShip.transform.position;
        // Destroy the current ship
        Destroy(currentShip);
        // Switch the ship
        if (currentShip.CompareTag("Ship1"))
        {
            currentShip = Instantiate(spaceShip2, shipPosition, Quaternion.Euler(0, 0, 180));   // Rotate the ship 180 degrees
            //currentShip.tag = "Ship2";
        }
        else
        {
            currentShip = Instantiate(spaceShip1, shipPosition, Quaternion.Euler(0, 0, 180));   // Rotate the ship 180 degrees
            //currentShip.tag = "Ship1";
        }
    }
}
