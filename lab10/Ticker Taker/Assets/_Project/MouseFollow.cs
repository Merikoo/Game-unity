using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourScriptName : MonoBehaviour
{
    public float smooth = 2.0f;
    public float tiltAngle = 30.0f;

    void Update()
    {
        float halfW = Screen.width / 2;
        transform.position = new Vector3((Input.mousePosition.x - halfW) / halfW, transform.position.y, transform.position.z);

        float halfH = Screen.height / 3;
        transform.position = new Vector3(transform.position.x, transform.position.y, (Input.mousePosition.y - halfH) / halfH);

        float tiltAroundZ = Input.GetAxis("Mouse X") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Mouse Y") * tiltAngle * -2;
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
