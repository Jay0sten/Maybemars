using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [Header("Tiles")]
    [SerializeField] private List<GameObject> Tiles = new List<GameObject>();
    [SerializeField] private GameObject RockTile;
    [SerializeField] private GameObject WallTile;

    [SerializeField] private GameObject TileParent; //GameObject that all tiles are children of to keep the heiarchy clean

    [HideInInspector] public Dictionary<string, BaseTile> TileDictionary = new Dictionary<string, BaseTile>();

    [Range(1, 5)]
    [SerializeField] private int MapScale;

    int _width = 16;
    int _height = 9;
    int width;
    int height;

    private void Awake()
    {
       
        width = _width * MapScale;
        height = _height * MapScale;

    }

    private void Start()
    {
        GenerateTiles();
    }

    public void GenerateTiles()
    {
       
        int rockweight = 90;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                if((x == 0 || x == width - 1) || (y == 0 || y == height - 1))
                {
                    var wallTile = Instantiate(WallTile, new Vector3(x,y), Quaternion.identity, TileParent.transform);
                    wallTile.name = $"Tile {x} {y}";
                    TileDictionary.Add(wallTile.name, wallTile.GetComponent<BaseTile>());
                    
                }
                else
                {
                    int random = Random.Range(0, 100);
                    if(random >= rockweight)
                    {
                        var rockTileSpawn = Instantiate(RockTile, new Vector3(x, y), Quaternion.identity, TileParent.transform);
                        rockTileSpawn.name = $"Tile {x} {y}";
                        TileDictionary.Add(rockTileSpawn.name, rockTileSpawn.GetComponent<BaseTile>());
                        rockweight--;
                    }
                    else
                    {
                        var spawnedTile = Instantiate(Tiles[0], new Vector3(x, y), Quaternion.identity, TileParent.transform);
                        spawnedTile.name = $"Tile {x} {y}";
                        TileDictionary.Add(spawnedTile.name, spawnedTile.GetComponent<BaseTile>());
                        if (rockweight <= 90)
                        rockweight += 5;
                    }
                    

                }
                //int random = Random.Range(0, Tiles.Count);
                
            }
        }
    }


    public BaseTile GetTile(string tileName)
    {
        return TileDictionary[tileName];
    }
}
