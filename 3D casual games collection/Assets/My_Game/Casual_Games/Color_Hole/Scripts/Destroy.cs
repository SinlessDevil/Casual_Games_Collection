using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private float _waitTime = 1f;
    private void Start()
    {
        Destroy(gameObject, _waitTime);
    }
}
