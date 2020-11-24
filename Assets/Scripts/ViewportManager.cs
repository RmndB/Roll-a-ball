using UnityEngine;

public class ViewportManager : MonoBehaviour
{
    private Camera cameraPlayerA;
    private Camera cameraPlayerB;

    private void Start()
    {
        cameraPlayerA = transform.GetChild(0).gameObject.GetComponent<Camera>();
        cameraPlayerB = transform.GetChild(1).gameObject.GetComponent<Camera>();

        if (PlayerManager.useAIasPlayerB)
        {
            cameraPlayerA.rect = new Rect(0, 0, 1, 1);
            cameraPlayerB.enabled = false;
        }
        else
        {
            cameraPlayerA.rect = new Rect(0, 0, 0.5f, 1);
            cameraPlayerB.rect = new Rect(0.5f, 0, 1, 1);
        }
    }
}
