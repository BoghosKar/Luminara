using UnityEngine;

public class LaserSight : MonoBehaviour
{
   public Transform gunTransform; // Reference to the gun's transform
    public LineRenderer laserSight; // Reference to the LineRenderer component

    private Camera mainCam;
    private RaycastHit2D hit;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        // Aim the gun at the mouse pointer
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - gunTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gunTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Perform a raycast to check for obstructions
        hit = Physics2D.Raycast(gunTransform.position, direction, Mathf.Infinity);

        // Update the laser sight positions
        if (hit.collider != null)
        {
            laserSight.SetPosition(0, gunTransform.position);
            laserSight.SetPosition(1, hit.point);
        }
        else
        {
            laserSight.SetPosition(0, gunTransform.position);
            laserSight.SetPosition(1, mousePos);
        }
    }
}
