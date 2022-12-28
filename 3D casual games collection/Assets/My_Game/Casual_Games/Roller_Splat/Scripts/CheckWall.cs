using System.Collections;
using UnityEngine;

public class CheckWall : MonoBehaviour{

    [SerializeField] private BoxCollider _boxCollider;

    private void Start()
    {
        StartCoroutine(CoroutineDestaroy(2f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Dictionary.nameTagWallComponent))
        {
            other.gameObject.SetActive(false);
        }
    }

    private IEnumerator CoroutineDestaroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _boxCollider.enabled = false;
    }
}
