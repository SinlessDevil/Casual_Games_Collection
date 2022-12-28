using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [Header("Level texture")]
    [SerializeField] private Texture2D[] _levelTexture;

    [Header("Tiles Prefab")]
    [SerializeField] private GameObject _prefabWallTile;
    [SerializeField] private GameObject _prefabRoadTile;

    [Header("Ball and Road paint color")]
    public Color paintColor;

    [HideInInspector] public List<RoadTile> roadTilesList = new List<RoadTile>();
    [HideInInspector] public RoadTile defaultBallRoadTile;

    private Color colorWall = Color.white;
    private Color colorRoad = Color.black;

    private float unitPerPixel;

    private void Awake()
    {
        GM_Roller_Splat.Instance.LoadLevel();
        Debug.Log(GM_Roller_Splat.Instance._currentLevel);
        if (GM_Roller_Splat.Instance._currentLevel >= GM_Roller_Splat.Instance._maxLevel){
            Generate(GM_Roller_Splat.Instance._maxLevel);
        }else{
            Generate(GM_Roller_Splat.Instance._currentLevel);
        }
        //assign first road tile as default poition for the ball:
        defaultBallRoadTile = roadTilesList[0];
    }

    private void Generate(int numberLevel)
    {
        unitPerPixel = _prefabWallTile.transform.lossyScale.x;
        float halfUnitPerPixel = unitPerPixel / 2f;

        float width = _levelTexture[numberLevel].width;
        float height = _levelTexture[numberLevel].height;

        Vector3 offset = (new Vector3(width / 2f, 0f, height / 2f) * unitPerPixel)
            - new Vector3(halfUnitPerPixel, 0f, halfUnitPerPixel);

        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++){
                //Get pixel color :
                Color pixelColor = _levelTexture[numberLevel].GetPixel(x, y);

                Vector3 spawnPos = ((new Vector3(x, 0f, y) * unitPerPixel) - offset);

                if (pixelColor == colorWall)
                    Spawn(_prefabWallTile, spawnPos);
                if (pixelColor == colorRoad)
                    Spawn(_prefabRoadTile, spawnPos);
            }
        }
    }

    private void Spawn(GameObject prefabTile, Vector3 position)
    {
        position.y = prefabTile.transform.position.y;

        GameObject obj = Instantiate(prefabTile, position, Quaternion.identity, transform);

        if (prefabTile == _prefabRoadTile)
            roadTilesList.Add(obj.GetComponent<RoadTile>());
    }
}
