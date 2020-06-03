using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private Texture2D crosshair; // Delete
    [SerializeField] private PlayerStats playerStats;
    private CharacterController characterController;

    [SerializeField] Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float jumpHeight;
    [SerializeField] private bool jumpingAllowed = false;

    private Vector3 velocity;
    private bool isGrounded;
    private const float Gravity = -9.81f;


    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(crosshair, new Vector2(16, 16), CursorMode.Auto);

        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsMouse();
        Move();
    }

    //private void Move()
    //{
    //    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    //    if (isGrounded && velocity.y < 0)
    //    {
    //        velocity.y = -2f;
    //    }

    //    float horizontal = Input.GetAxis("Horizontal");
    //    float vertical = Input.GetAxis("Vertical");

    //    Vector3 moveDirectionZ = transform.TransformDirection(Vector3.forward) * vertical;
    //    Vector3 moveDirectionX = transform.TransformDirection(Vector3.right) * horizontal;

    //    if (Input.GetButtonDown("Jump") && isGrounded && jumpingAllowed)
    //    {
    //        velocity.y = Mathf.Sqrt(jumpHeight * -2 * Gravity);
    //    }

    //    characterController.Move(moveDirectionZ * playerStats.MovementSpeed * Time.deltaTime);
    //    characterController.Move(moveDirectionX * playerStats.MovementSpeed * Time.deltaTime);

    //    velocity.y += Gravity * Time.deltaTime;

    //    characterController.Move(velocity * Time.deltaTime);
    //}

    //private void Move()
    //{
    //    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    //    if (isGrounded && velocity.y < 0)
    //    {
    //        velocity.y = -2f;
    //    }

    //    float horizontal = Input.GetAxis("Horizontal");
    //    float vertical = Input.GetAxis("Vertical");

    //    Vector3 move = new Vector3(horizontal, 0f, vertical);

    //    if (Input.GetButtonDown("Jump") && isGrounded && jumpingAllowed)
    //    {
    //        velocity.y = Mathf.Sqrt(jumpHeight * -2 * Gravity);
    //    }

    //    characterController.Move(move * playerStats.MovementSpeed * Time.deltaTime);
    //    animator.SetFloat("VelX", horizontal);
    //    animator.SetFloat("VelY", vertical);

    //    velocity.y += Gravity * Time.deltaTime;

    //    characterController.Move(velocity * Time.deltaTime);
    //}

    private void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0f, vertical);

        if (Input.GetButtonDown("Jump") && isGrounded && jumpingAllowed)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * Gravity);
        }

        Vector3 localVel = transform.InverseTransformDirection(move);

        //if (localVel.x < 0.5) animator.SetFloat("VelX", localVel.x);
        //else if (localVel.x > 0.5) animator.SetFloat("VelX", 1f);
        //else if (localVel.z > 0.5) animator.SetFloat("VelY", 1f);
        //else if (localVel.z < 0.5) animator.SetFloat("VelY", -1f);

        //if (localVel.z == 0)
        //{
        //    animator.SetFloat("VelX", 0f);
        //    animator.SetFloat("VelY", 0f);
        //}

        //Debug.Log("horizontal: " + animator.GetFloat("VelX") + " velocity: " + animator.GetFloat("VelY") + " local vel: " + localVel);

        characterController.Move(move * playerStats.MovementSpeed * Time.deltaTime);

        animator.SetFloat("VelX", localVel.x);
        animator.SetFloat("VelY", localVel.z);

        velocity.y += Gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    private void RotateTowardsMouse()
    {
        transform.LookAt(DataStorage.MouseInfo.ReturnMousePos(this.transform));
    }

}
