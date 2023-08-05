using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform centralAxis;
    public Transform cam;  // 줌 in/out
    public float camSpeed;
    float mouseX;
    float mouseY;
    float wheel = -12; 

    void CamMove()
    {
        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y") * -1; // 상하반전을 위해 -1을 *해줌

            centralAxis.rotation = Quaternion.Euler(new Vector3(centralAxis.rotation.x + mouseY, centralAxis.rotation.y + mouseX, 0) * camSpeed);
        }
    }

    void Zoom()
    {
        wheel += Input.GetAxis("Mouse ScrollWheel");
        if (wheel >= -1)
            wheel = -1;
        if (wheel <= -15)
            wheel = -15;
        cam.localPosition = new Vector3(0, 0, wheel);

        // 일정 이상 당기면 1인칭으로 변경
        //if (wheel == -1)
        //    cam.localPosition = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        CamMove();
        Zoom();
    }
}
