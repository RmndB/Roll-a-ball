using UnityEngine;

public class SelfRotation : MonoBehaviour
{
    private const int ROTATION_SPEED_LIMIT = 5;

    private int rotationSpeed;

    private void Start()
    {
        rotationSpeed = Random.Range(-ROTATION_SPEED_LIMIT, ROTATION_SPEED_LIMIT);
    }

    private void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
    }
}