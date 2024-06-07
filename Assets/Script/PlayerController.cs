using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // SETTINGS AND FIELDS

    // Get head reference
   [SerializeField] Transform head;
   [SerializeField] float mouseSensitivity = 2.0f;
   [SerializeField] float movementSpeed = 5.0f;
   [SerializeField] float gravity = -9.81f;
   [SerializeField] float jumpForce = 2.0f;
   
    // Flashlight
    [SerializeField] Flashlight lamp; // reference for the flashlight

    // UI manager
    [SerializeField] InGameUIManager uiManager;

    // Naive score keeper
    ScoreKeeper scoreKeeper; // Keeps count of the coins


    // Create an empty character controller
    CharacterController characterController;

    // remember head x-rotation
    float xRotation;

    // remember velocity
    Vector3 velocity;

    void Start()
    {
        // SETUP

        // Find the score keeper script in game world
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();

        // fetch our character controller
        characterController = GetComponent<CharacterController>();

        // lock and hide the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {

        // read input from keyboard
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");


        // read input from mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Head looking up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //constraint head
        head.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate characters body left and right
        transform.Rotate(Vector3.up * mouseX);

        // Create movement vector
        Vector3 movement = transform.right * movementHorizontal + transform.forward * movementVertical;

        // Dont fall if we are touching the ground (get rid of execc velocity)
        if(characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // stick to the ground
        }

        // Jumping
        if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // calculate velocity
        velocity.y += gravity * Time.deltaTime;

        // apply movement
        characterController.Move((movement * movementSpeed + velocity) * Time.deltaTime);

        // Toggle flashlight on/off if we press left mouse button

        if (Input.GetMouseButtonDown(0))
        {
            lamp.ToggleLamp();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // We got trigered by the coin

        if(other.gameObject.tag == "Coin")
        {
            scoreKeeper.AddCoin();
            uiManager.UpdateScoreText();
            Destroy(other.gameObject);
        }
    }


}
