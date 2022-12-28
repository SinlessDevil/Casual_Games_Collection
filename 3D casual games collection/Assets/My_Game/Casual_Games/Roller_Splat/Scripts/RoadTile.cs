using UnityEngine;

public class RoadTile : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Vector3 position;
    public bool isPainted;

    private void Awake()
    {
        position = transform.position;
        isPainted = false;
    }

}
