using UnityEngine;
[System.Serializable]
public class AnimationBlender
{
    public string _top, _bottom, _left, _right;
    public AnimationBlender(string top, string bottom, string left, string right)
    {
        _top = top;
        _bottom = bottom;
        _left = left;
        _right = right;
    }
    // blends the vector then converts it to the animation string, returns the result.
    public string GetBlendedAnimation(Vector2 inputVector) => GetAnimStateNameFromDirection(BlendVector2(inputVector));
    // blends a vector2 to one of the four cardinal directions
    private Vector2Int BlendVector2(Vector2 ToBlend)
    {
        float SmallestDist = 10;
        Vector2Int StoredDir = Vector2Int.zero;
        foreach (Vector2Int V in Constants.CardianlsVi)
        {
            float dist = Vector2.Distance(ToBlend, V);
            if (SmallestDist > dist)
            {
                SmallestDist = dist;
                StoredDir = V;
            }
        }
        return StoredDir;
    }
    // returns the animation name for whatever cardinal direction its fed.
    private string GetAnimStateNameFromDirection(Vector2Int direction)
    {
        if (direction == Vector2Int.down)
            return _bottom;
        if (direction == Vector2Int.up)
            return _top;
        if (direction == Vector2Int.left)
            return _left;
        if (direction == Vector2Int.right)
            return _right;
        return "";
    }
}