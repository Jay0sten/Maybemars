using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public int objectHealth;
    //Resistance should be a low number as it will subtract from the damage dealt. If the resistance is too high, it may heal itself...
    public int resistance;
    public GameObject deatheffect;


    public void TakeDamage(int damage)
    {

        
        objectHealth -= (damage - resistance);
        if (objectHealth <= 0)
        {

            Die();
        
        
        
        }


    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Die();
        }
    }


    private void Die()
    {
        if (deatheffect != null)
        {
            Instantiate(deatheffect,gameObject.transform.position, transform.localRotation);
        }
            
       
        
        Destroy(gameObject);
    }
}
