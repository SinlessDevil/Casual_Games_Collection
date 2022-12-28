using UnityEngine;

public class Orientation : MonoBehaviour
{
    public enum TypeOrientation
    {
        Portan,
        LandSpace
    }
    public TypeOrientation typeOrientation;

    private void Awake()
    {
        switch (typeOrientation)
        {
            case TypeOrientation.Portan:
                Screen.orientation = ScreenOrientation.Portrait;
                break;
            case TypeOrientation.LandSpace:
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                break;
        }
    }
}
