using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class TutorialMovement : MonoBehaviour
    {

        private Vector2 rotation = Vector2.zero;
        Vector3 moveVector;
        public CharacterController characterController;

        public float moveSpeed = 10;
        public float jumpSpeed = 6;
        public float gravity = 20;
        public float lookSpeed = 3;


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
        }

    public void Look()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }

    }