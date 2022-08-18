using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float rotationXSpeed = 500f;
    [SerializeField] private float rotationYSpeed = 100f;

    private Vector3 targetPoint;

    private float rotationX;
    private float rotationY;


    private void Start()
    {
        //targetPoint = target.transform.position;
        targetPoint = new Vector3(2.5f, 0, 2.5f);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rotationX = Input.GetAxis("Mouse X") * Time.deltaTime * rotationXSpeed;
            rotationY = Input.GetAxis("Mouse Y") * Time.deltaTime * rotationYSpeed;

            transform.RotateAround(targetPoint, Vector3.up, rotationX);
            transform.RotateAround(targetPoint, Vector3.right, -rotationY);
        }

        //transform.RotateAround(targetPoint, Vector3.up, Mathf.Lerp(rotationX, 0, Time.deltaTime));
        //transform.RotateAround(targetPoint, Vector3.right, Mathf.Lerp(-rotationY, 0, Time.deltaTime));

        transform.LookAt(targetPoint);
    }
}
