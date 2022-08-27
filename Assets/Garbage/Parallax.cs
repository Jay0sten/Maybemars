using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float multiplier;
    public GameObject camera;
    private Vector3 startPostion;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime;

    private void Start()
    {
        startPostion = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 nextPos = new Vector3(startPostion.x * (multiplier * camera.transform.position.x), transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, nextPos, ref velocity, smoothTime);
    }
}
