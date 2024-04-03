using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    [SerializeField]
    private Transform character;
    [SerializeField] 
    private float smoothTime = 1.5f;

    private Vector3 vel;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,character.position+new Vector3(0f,0f,transform.position.z), smoothTime);

    }
}