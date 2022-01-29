using UnityEngine;
using UnityEngine.Tilemaps;

public class DimensionalShiftManager : MonoBehaviour
{
    [SerializeField] string changeDimensionButtonName = "ChangeDimension";
    [SerializeField] DimensionalShiftMapping[] tileMappings;
    [SerializeField] WorldType worldType = WorldType.LIGHT;

    Tilemap tilemap;

    public WorldType WorldType
    {
        get { return worldType; }
        set
        {
            worldType = value;
        }
    }

    private void Start()
    {
        GameObject tilemapGo = GameObject.FindGameObjectWithTag("Tilemap");
        tilemap = tilemapGo.GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(changeDimensionButtonName))
        {
            toggleWorld();
        }
    }

    void toggleWorld()
    {
        if(WorldType == WorldType.LIGHT)
        {
            WorldType = WorldType.DARK;
        }
        else
        {
            WorldType = WorldType.LIGHT;
        }

        switchWorldTo(WorldType);
    }

    void switchWorldTo(WorldType type)
    {
        foreach (DimensionalShiftMapping mapping in tileMappings)
        {
            if (type == WorldType.LIGHT)
            {
                tilemap.SwapTile(mapping.darkTile, mapping.lightTile);
            }
            else
            {
                tilemap.SwapTile(mapping.lightTile, mapping.darkTile);
            }
        }
    }
}
