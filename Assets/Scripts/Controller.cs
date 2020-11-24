using System;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private const float SPEED = 10.0f;
    private const float JUMP_HEIGHT = 2.0f;

    [SerializeField]
    private int controller = default;
    [SerializeField]
    private LayerMask groundLayer = default;
    [SerializeField]
    private int id = default;

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
        if (controller == 0)
        {
            x = Input.GetAxis("HorizontalKeyboard" + id);
            y = Input.GetAxis("VerticalKeyboard" + id);

            if (Input.GetButtonDown("JumpKeyboard" + id) && isGrounded)
            {
                Jump();
            }
        }
        else if (controller == 1)
        {
            x = Input.GetAxis("HorizontalGamepad" + id);
            y = -Input.GetAxis("VerticalGamepad" + id);

            if (Input.GetButtonDown("JumpGamepad" + id) && isGrounded)
            {
                Jump();
            }
        }
        else
        {
            throw new Exception("Controller not handled, please choose 0 for keyboard or 1 for gamepad");
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

    public void Jump()
    {
        rigidbody.AddForce(Vector3.up * Mathf.Sqrt(JUMP_HEIGHT * -2f * Physics.gravity.y), ForceMode.VelocityChange);
    }
}