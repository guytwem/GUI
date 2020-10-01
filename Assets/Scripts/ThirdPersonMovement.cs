using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cam;
    [SerializeField] public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    [SerializeField] private Vector3 playerVelocity;

    public PlayerStats playerStats;






    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();

    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            float movementSpeed = playerStats.speed;
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))

            {
                movementSpeed = playerStats.sprintSpeed;
            }
            else
            {
                movementSpeed = playerStats.crouchSpeed;
            }
            controller.Move(moveDir * playerStats.speed * Time.deltaTime);
        }
    }
    private void Jump()
    {
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(playerStats.jumpHeight * -3.0f * playerStats.gravity);
        }

        playerVelocity.y += playerStats.gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


    bool isGrounded()
    {
        Debug.DrawRay(transform.position, -Vector3.up * ((controller.height * 0.5f) * 1.1f), Color.red);
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, controller.radius, -Vector3.up, out hit, controller.height + 0.1f - controller.bounds.extents.x, layerMask))
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + (-Vector3.up * (controller.bounds.extents.y + 0.1f - controller.bounds.extents.x)), controller.radius);
    }

}
