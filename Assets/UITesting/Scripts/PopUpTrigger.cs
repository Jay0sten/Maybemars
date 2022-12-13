using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PopUpTrigger : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Inventory inventory = collision.GetComponent<Inventory>();
            if(inventory != null)
            {

            }
        }
    }
}
