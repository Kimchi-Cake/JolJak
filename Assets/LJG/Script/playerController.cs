using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class playerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public Transform cameraTransform;

    private CharacterController controller;
    private float yVelocity = 0f;
    private float turnSmoothVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // �߷� ó��
        if (controller.isGrounded && yVelocity < 0)
            yVelocity = -2f;
        else
            yVelocity += gravity * Time.deltaTime;

        // �Է�
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = new Vector3(h, 0, v).normalized;

        if (inputDir.magnitude >= 0.1f)
        {
            // ī�޶� ���� �̵� ���� ���
            float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Vector3 move = moveDir.normalized * moveSpeed;

            move.y = yVelocity;
            controller.Move(move * Time.deltaTime);
        }
        else
        {
            // �� ������ �� �߷¸� ����
            Vector3 move = new Vector3(0f, yVelocity, 0f);
            controller.Move(move * Time.deltaTime);
        }
    }
}
