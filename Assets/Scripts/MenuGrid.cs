using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGrid : MonoBehaviour
{
    [SerializeField] private Image HolderPrefab;
    [SerializeField] private Canvas canvas;
    public int tempX;
    public int tempY;


    private void Update()
    {
        if(Input.GetKey(KeyCode.U))
        {
            GenerateMenu();
        }
    }
    public void GenerateMenu()
    {
        for (int x = 0; x < tempX; x++)
        {
            for (int y = 0; y < tempY; y++)
            {
                var holder = Instantiate(HolderPrefab, canvas.transform);
                holder.rectTransform.anchoredPosition = new Vector2(x * 100, y * 100);
                
                
            }

        }
    }
}
