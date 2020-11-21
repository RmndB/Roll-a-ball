using UnityEngine;

public class Controller : MonoBehaviour
{
    private const float SPEED = 10.0f;
    private const float JUMP_HEIGHT = 2.0f;

    [SerializeField]
    public LayerMask groundLayer;

    [SerializeField]
    public int id;

    private new Rigidbody rigidbody;
    private bool isGrounded;
    private float x;
    private float y;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal" + id);
        y = Input.GetAxis("Vertical" + id);

        if (Input.GetButtonDown("Jump" + id) && isGrounded)
        {
            jump();
        }
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(x, 0.0f, y) * SPEED);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false;
        }
    }

    public void jump()
    {
        rigidbody.AddForce(Vector3.up * Mathf.Sqrt(JUMP_HEIGHT * -2f * Physics.gravity.y), ForceMode.VelocityChange);
    }
}