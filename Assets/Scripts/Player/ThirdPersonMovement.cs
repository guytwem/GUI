using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonMovement : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Player player;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cam;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float gravity = -9.81f;
    float turnSmoothVelocity;

    [SerializeField] private Stamina stamina;

    [SerializeField] private Vector3 playerVelocity;

    private bool isGrounded;

    private void FixedUpdate()
    {
        isGrounded = IsGrounded();
    }

   

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

            float movementSpeed = player.playerStats.stats.speed;
            if (player.playerStats.stats.currentStamina > 0 && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))

            {
                player.disableStaminaRegenTime = Time.time;
                player.playerStats.stats.currentStamina -= player.StaminaDegen * Time.deltaTime;
                movementSpeed = player.playerStats.stats.sprintSpeed;
                stamina.StaminaChange();
            }
            else if(Input.GetKey(KeyCode.C))
            {
                movementSpeed = player.playerStats.stats.crouchSpeed;
            }
            controller.Move(moveDir * movementSpeed * Time.deltaTime);
        }
    }
    private void Jump()
    {
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(player.playerStats.stats.jumpHeight * -3.0f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


    bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector3.up * ((controller.height * 0.5f) * 1.1f), Color.red);
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, controller.radius, -Vector3.up, out hit, controller.bounds.extents.y + 0.1f - controller.bounds.extents.x, layerMask))
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + (-Vector3.up * (controller.bounds.extents.y + 0.1f - controller.bounds.extents.x)), controller.radius);
    }
    
}
