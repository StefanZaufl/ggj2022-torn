using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class DimensionalShiftManager : MonoBehaviour
{
    public delegate void WorldChangeDelegate(WorldType newWorldType);
    public static event WorldChangeDelegate worldChangeBeginEvent;
    public static event WorldChangeDelegate worldChangedEvent;

    [SerializeField] string changeDimensionButtonName = "ChangeDimension";
    [SerializeField] DimensionalShiftMapping[] tileMappings;
    [SerializeField] WorldType worldType = WorldType.LIGHT;
    [SerializeField] float worldChangeDelay = 0.5f;
    [SerializeField] bool autoChangeWorld = true;
    [SerializeField] float autoChangeWorldInterval = 45f;

    Tilemap[] tilemaps;
    bool changingWorld = false;
    float worldChangeTimer = 0f;

    public WorldType WorldType
    {
        get { return worldType; }
    }

    private void Start()
    {
        tilemaps = GetComponentsInChildren<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!changingWorld && Input.GetButtonDown(changeDimensionButtonName) && !autoChangeWorld)
        {
            toggleWorld();
        }

        if(autoChangeWorld)
        {
            worldChangeTimer += Time.deltaTime;

            if(worldChangeTimer > autoChangeWorldInterval)
            {
                worldChangeTimer = 0f;
                toggleWorld();
            }
        }
    }

    public void toggleWorld()
    {
        WorldType newType;

        if(worldType == WorldType.LIGHT)
        {
            newType = WorldType.DARK;
        }
        else
        {
            newType = WorldType.LIGHT;
        }

        StartCoroutine(startSwitchinggWorld(newType));
    }

    IEnumerator startSwitchinggWorld(WorldType newType)
    {
        Debug.Log("Start Switching World...");

        changingWorld = true;
        worldChangeBeginEvent?.Invoke(newType);
        yield return new WaitForSeconds(worldChangeDelay);
        switchWorldTo(newType);
        changingWorld = false;
    }

    void switchWorldTo(WorldType newType)
    {
        foreach (DimensionalShiftMapping mapping in tileMappings)
        {
            if (newType == WorldType.LIGHT)
            {
                swapTiles(mapping.darkTile, mapping.lightTile);
            }
            else
            {
                swapTiles(mapping.lightTile, mapping.darkTile);
            }
        }

        try
        {
            Debug.Log("World Changed to " + newType);
            worldChangedEvent?.Invoke(newType);
        }
        finally
        {
            worldType = newType;
        }
    }

    void swapTiles(TileBase from, TileBase to)
    {
        foreach(Tilemap tilemap in tilemaps)
        {
            tilemap.SwapTile(from, to);
        }
    }

    public static DimensionalShiftManager Instance
    {
        get
        {
            GameObject go = GameObject.FindGameObjectWithTag("World");
            return go.GetComponent<DimensionalShiftManager>();
        }
    }
}
