using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCamera : MonoBehaviour
{
    public Transform target;
    public float GroundDistance = 5f;
    public float heightOffset = 3f;
    public float cameraDelay = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followPos = target.position - target.forward * GroundDistance;
        followPos.y += heightOffset;
        transform.position += (followPos - transform.position) * cameraDelay;

        transform.LookAt(target.transform);
    }
}
