using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Reagant> ingredients;

    private void Awake()
    {
        ingredients = new List<Reagant> ();
    }


    /// <summary>
    /// Adds an ingredient to player inventory
    /// </summary>
    /// <param name="ingredient"></param>
    public void AddIngredientInventory(Reagant ingredient)
    {
        ingredients.Add (ingredient);
    }
}
