using UnityEngine;

public class FX : MonoBehaviour
{
    [SerializeField] private ParticleSystem cubeExplosionFX;

    private ParticleSystem.MainModule _cubeExplosionFXMainModule;

    //singleton class
    public static FX Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _cubeExplosionFXMainModule = cubeExplosionFX.main;
    }

    public void PlayCubeExplsionFX(Vector3 position, Color color)
    {
        _cubeExplosionFXMainModule.startColor = new ParticleSystem.MinMaxGradient(color);
        cubeExplosionFX.transform.position = position;
        cubeExplosionFX.Play();
    }

}
