using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]


public class Ingredient : MonoBehaviour
{
    public Reagant reagant;
    Sprite sprite;
    SpriteRenderer renderer;
    


    private void Awake()
    {
        
        renderer = GetComponent<SpriteRenderer>();
        sprite = reagant.sprite;
        renderer.sortingOrder = 2;
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
            Inventory inventory = collision.GetComponent<Inventory>();
            if(inventory != null)
            {

                inventory.AddIngredientInventory(reagant);
                if(reagant.type == ReagantType.Oxide)
                {
                    PlayerStats stats = collision.GetComponent<PlayerStats>();
                    try
                    {
                        stats.Oxygen += 1;
                        stats.OxygenStatBar.SetValue(stats.Oxygen);
                    }
                    catch(Exception e)
                    {
                        Debug.Log(e.Message);
                    }
                }
                
                Destroy(gameObject);
            }
            else
            {
                return;
            }
            

        }
    }
}
