using UnityEngine;

public class AnimationBlender
{
    string _top;
    string _bottom;
    string _left;
    string _right;

    public AnimationBlender(string top, string bottom, string left, string right)
    {
        _top = top;
        _bottom = bottom;
        _left = left;
        _right = right;
    }

    public string GetBlendedAnimation(Vector2 inputVector)
    {
        // TODO: blend the vector and determine which animation should be returned
        
        // for now it return empty string, so compiler wont scream
        return "";
    }
}