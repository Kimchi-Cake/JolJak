using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;  // Player
    public Vector3 offset = new Vector3(0f, 2f, -4f);
    public float mouseSensitivity = 5f;

    private float yaw = 0f;

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        yaw += mouseX;

        // 캐릭터도 함께 회전
        target.rotation = Quaternion.Euler(0f, yaw, 0f);

        // 카메라 위치 계산
        Vector3 rotatedOffset = Quaternion.Euler(0f, yaw, 0f) * offset;
        transform.position = target.position + rotatedOffset;

        // 카메라는 항상 타겟을 바라봄
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
