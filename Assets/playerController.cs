using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5f;   //�̵�
    public float rotationSpeed = 10f;

    private Transform cameraTransform;
    private CharacterController characterController;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal"); //�̵�
        float vertical = Input.GetAxisRaw("Vertical");     //�̵�
        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;
            cameraForward.y = 0f;
            cameraRight.y = 0f;
            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 moveDirection = cameraForward * vertical + cameraRight * horizontal;
            moveDirection.Normalize();
            
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}
