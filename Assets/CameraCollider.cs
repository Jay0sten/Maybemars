using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    BoxCollider2D collider;
    public LayerMask masks;
    private void Awake()
    {
        Physics2D.IgnoreLayerCollision(9, masks);
    }
}
