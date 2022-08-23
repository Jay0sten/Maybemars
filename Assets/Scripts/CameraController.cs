using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject followObject;
    public Vector2 followOffset;
    public float speed = 3f;
    public Vector2 threshold;
    private Rigidbody2D rb;
    
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        threshold = calculateThreshold();
        rb = followObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 follow = followObject.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;
        
        if(Mathf.Abs(xDifference) >= threshold.x)
        {
            newPosition.x = follow.x;
        }
        if(Mathf.Abs(yDifference) >= threshold.y)
        {
            newPosition.y = follow.y;
        }

        //float movespeed  = rb.velocity.magnitude > speed ? rb.velocity.magnitude : speed ;
       //transform.position = Vector3.MoveTowards(transform.position, newPosition, movespeed * Time.fixedDeltaTime);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, 0.5f) ;
        
    }
    
    private Vector3 calculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.height / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }

}
