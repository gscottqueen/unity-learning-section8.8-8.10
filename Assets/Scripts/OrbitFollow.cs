using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitFollow : MonoBehaviour
{

    public Transform target;
    public float speed;


    // Update is called once per frame
    private void Update()
    {
        // Calculate the relative position
        Vector3 relativePos = target.position + new Vector3(0, 2f, 0) - transform.position;

        // Create a look rotation based on the relativePos
        Quaternion lookRot = Quaternion.LookRotation(relativePos);

        // Current rotation
        Quaternion current = transform.rotation;

        // sperically interpolate between current and look rotation;
        transform.localRotation = Quaternion.Slerp(current, lookRot, Time.deltaTime);

        // move the drone forward
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
