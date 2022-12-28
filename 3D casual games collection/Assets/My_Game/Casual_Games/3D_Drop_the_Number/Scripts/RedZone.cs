using UnityEngine;
using UnityEngine.SceneManagement;

public class RedZone : MonoBehaviour{
    private void OnTriggerStay(Collider other)
    {
        Cube cube = other.GetComponent<Cube>();
        if(cube != null)
        {
            if(!cube.isMainCube && cube.cubeRigidbody.velocity.magnitude < 0.1f)
            {
                GM_Mega_Cube.Instance.GameOver(false);
            }
        }
    }
}
