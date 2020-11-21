using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Vector3 OFFSET { get { return new Vector3(0, 15, -15); } }

    [SerializeField]
    private GameObject player;

    private Vector3 offset;

    private void Update()
    {
        transform.position = (player.transform.position + OFFSET);
        transform.LookAt(player.transform);
    }
}
