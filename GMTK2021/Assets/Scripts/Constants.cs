using UnityEngine;
public static class Constants
{
    public static readonly Vector2[] CardianlsVf = { Vector2Int.down, Vector2Int.up, Vector2Int.left, Vector2Int.right };
    public static readonly Vector2Int[] CardianlsVi = { Vector2Int.down, Vector2Int.up, Vector2Int.left, Vector2Int.right };
    public static readonly Vector2[] CardianlsVfZero = { Vector2Int.down, Vector2Int.up, Vector2Int.left, Vector2Int.right, Vector2Int.zero };
    public static readonly Vector2Int[] CardianlsViZero = { Vector2Int.down, Vector2Int.up, Vector2Int.left, Vector2Int.right, Vector2Int.zero };
    public static readonly Vector2Int[] CardinalsAndDiagonalsZeroVi = { Vector2Int.down, Vector2Int.up, Vector2Int.left, Vector2Int.right, Vector2Int.zero, new Vector2Int(-1, -1), new Vector2Int(1, -1), new Vector2Int(-1, 1), new Vector2Int(1, 1) };
    public static readonly Vector2[] Diagonals = { new Vector2(-0.75f, -0.75f), new Vector2(-0.75f, 0.75f), new Vector2(0.75f, -0.75f), new Vector2(0.75f, 0.75f) };
    public static readonly Vector2[] DiagonalsZero = { new Vector2(-0.75f, -0.75f), new Vector2(-0.75f, 0.75f), new Vector2(0.75f, -0.75f), new Vector2(0.75f, 0.75f), Vector2.zero };
    public static readonly Vector2[] CardinalsAndDiagonals = { Vector2.down, Vector2.up, Vector2.left, Vector2.right, new Vector2(-0.75f, -0.75f), new Vector2(-0.75f, 0.75f), new Vector2(0.75f, -0.75f), new Vector2(0.75f, 0.75f) };
    public static readonly Vector2[] CardinalsAndDiagonalsZeroVf = { Vector2.down, Vector2.up, Vector2.left, Vector2.right, new Vector2(-0.75f, -0.75f), new Vector2(-0.75f, 0.75f), new Vector2(0.75f, -0.75f), new Vector2(0.75f, 0.75f), Vector2.zero };
}