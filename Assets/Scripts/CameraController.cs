using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public  GameObject  look;
    
    void LateUpdate()
    {
        transform.position = new Vector3(look.transform.position.x, look.transform.position.y, transform.position.z);
    }
}
