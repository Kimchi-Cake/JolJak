using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;  
    public Vector3 offset = new Vector3(0f, 2f, -4f);
    public float mouseSensitivity = 5f;

    private float yaw = 0f;

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        yaw += mouseX;


        target.rotation = Quaternion.Euler(0f, yaw, 0f);


        Vector3 rotatedOffset = Quaternion.Euler(0f, yaw, 0f) * offset;
        transform.position = target.position + rotatedOffset;

  
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
