using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileMapping", menuName = "World/DimensionalShiftMapping", order = 1)]
public class DimensionalShiftMapping : ScriptableObject
{
    public TileBase lightTile;
    public TileBase darkTile;
}