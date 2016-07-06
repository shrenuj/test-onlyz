using UnityEngine;
using System.Collections;

/// <summary>
/// Simple Object Follow Class.  We use this to make the Camera follow the player.
/// </summary>
public class ObjectFollow : MonoBehaviour
{
    public Transform target;            // The position that that camera will be following.
    public Transform target2;            // The position that that camera will be following.

    public float smoothing = 5f;        // The speed with which the camera will be following.
    Vector3 offset;                     // The initial offset from the target.
    Vector3 offset1;                     // The initial offset from the target.
    Vector3 offset2;                     // The initial offset from the target.

    void Start()
    {
        // Calculate the initial offset.
        offset1 = transform.position - target.position;
        offset2 = transform.position - target2.position;
        offset = (offset1+ offset2)/2;

    }

    void FixedUpdate()
    {
        // Create a position the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position/2 + target2.position / 2 + offset;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }


}
