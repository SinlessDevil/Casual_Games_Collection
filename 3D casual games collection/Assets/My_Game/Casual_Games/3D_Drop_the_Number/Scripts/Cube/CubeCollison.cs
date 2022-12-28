using UnityEngine;

public class CubeCollison : MonoBehaviour
{
    private Cube _cube;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    private void OnCollisionEnter(Collision collision){
        Cube otherCube = collision.gameObject.GetComponent<Cube>();
        //check if contacted with other cube
        if(otherCube != null && _cube.cubeID > otherCube.cubeID){
            //check if both cubes have same number
            if(_cube.cubeNumber == otherCube.cubeNumber){
                int resultHit = _cube.cubeNumber + otherCube.cubeNumber;
                if(resultHit > GM_Mega_Cube.Instance.currenMaxNumber){
                    GM_Mega_Cube.Instance.currenMaxNumber = resultHit;
                    GM_Mega_Cube.Instance.UpdateProgressMegaCube();
                    if (resultHit == GM_Mega_Cube.Instance.lastNumber){
                        GM_Mega_Cube.Instance.GameOver(true);
                    }
                }

                Vector3 contactPoint = collision.contacts[0].point;

                //check if cubes number less than max number in CubeSpawner:
                if(otherCube.cubeNumber < CubeSpawner.Instance.maxCubeNumber){
                    AudioManager.Instance.PlayClip(Dictionary.nameAudioClipMegaCubeDestroyCube);
                    //spawn a new as a result
                    Cube newCube = CubeSpawner.Instance.Spawn(_cube.cubeNumber * 2, contactPoint + Vector3.up * 1.6f);

                    //push the new cube up and forward:
                    float pushForce = 2.5f;
                    newCube.cubeRigidbody.AddForce(new Vector3(0, 0.3f, 1f) * pushForce, ForceMode.Impulse);

                    //add some torque:
                    float randomValue = Random.Range(-20f, 20f);
                    Vector3 randomDirection = Vector3.one * randomValue;
                    newCube.cubeRigidbody.AddForce(randomDirection);
                }

                //the explosion should affect surrounded cubers too:
                Collider[] surroundedCubes = Physics.OverlapSphere(contactPoint, 2f);
                float explosionForce = 400f;
                float explosionRadius = 1.5f;

                foreach (Collider coll in surroundedCubes){
                    if (coll.attachedRigidbody != null)
                        coll.attachedRigidbody.AddExplosionForce(explosionForce, contactPoint, explosionRadius);
                }

                //TODO : explosion FX
                FX.Instance.PlayCubeExplsionFX(contactPoint, _cube.cubeColor);

                //Destroy the two cubes:
                CubeSpawner.Instance.DestroyCube(_cube);
                CubeSpawner.Instance.DestroyCube(otherCube);
            }
        }
    }

}
