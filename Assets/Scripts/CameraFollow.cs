using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float dampening;

    public Transform target;
    private Vector3 vel = Vector3.zero;
    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            //locks z in place
            targetPosition.z = transform.position.z;
            //prevents the camera from moving in the starting area 
            if (target.position.y < 25 && target.position.x > -20)
            {
                targetPosition.x = 0;
            }
            //camera follows the player
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, dampening);
        }
    }
}
