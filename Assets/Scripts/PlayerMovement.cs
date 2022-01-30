using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 moveVector;
    public CharacterController characterController;

    public float moveSpeed = 10;
    public float jumpSpeed = 6;
    public float gravity = 20;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (characterController.isGrounded && Input.GetButton("Jump"))
            moveVector.y = jumpSpeed;

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * moveSpeed * Time.deltaTime);

        moveVector.y -= gravity * Time.deltaTime;
        characterController.Move(moveVector * Time.deltaTime);

        if (move.magnitude > 0 && characterController.isGrounded)
            TriggerWalkSound();
    }

    void TriggerWalkSound()
    {
        int soundIndex = Random.Range(1, 5);
        FindObjectOfType<AudioManager>().Play($"step_wood", soundIndex);
    }
}