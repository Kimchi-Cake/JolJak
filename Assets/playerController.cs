using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5f;
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
        // 입력 받기
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D
        float vertical = Input.GetAxisRaw("Vertical");     // W/S
        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            // 카메라 기준으로 방향 회전
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;
            cameraForward.y = 0f;
            cameraRight.y = 0f;
            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 moveDirection = cameraForward * vertical + cameraRight * horizontal;
            moveDirection.Normalize();

            // 캐릭터 회전 (바라보는 방향)
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // 이동
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}
