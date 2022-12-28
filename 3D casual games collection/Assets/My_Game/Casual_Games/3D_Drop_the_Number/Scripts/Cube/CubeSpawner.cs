using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    // Singleton class
    public static CubeSpawner Instance;

    private Queue<Cube> _cubesQueue = new Queue<Cube>();
    [SerializeField] private int _cubesQueueCapacity = 20;
    [SerializeField] private bool _autoQueueGrow = true;

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Color[] _cubeColors;

    [HideInInspector] public int maxCubeNumber;
    //in our case it's 65,536 (2^16)

    private int maxPower = 16;

    private Vector3 _defaultSpawnPoint;

    private void Awake()
    {
        Instance = this;

        _defaultSpawnPoint = transform.position;
        maxCubeNumber = (int)Mathf.Pow(2, maxPower);

        InitializeCubessQueue();
    }

    private void InitializeCubessQueue(){
        for (int i = 0; i < _cubesQueueCapacity; i++)
        {
            AddCubeToQueue();
        }
    }

    private void AddCubeToQueue()
    {
        Cube cube = Instantiate(_cubePrefab, _defaultSpawnPoint, Quaternion.identity, transform)
                                .GetComponent<Cube>();

        cube.gameObject.SetActive(false);
        cube.isMainCube = false;
        _cubesQueue.Enqueue(cube);
    }

    public Cube Spawn(int number, Vector3 position){
        if(_cubesQueue.Count == 0){
            if (_autoQueueGrow){
                _cubesQueueCapacity++;
                AddCubeToQueue();
            }else{
                Debug.LogError("[Cubes Queue] : no more cubes availabe in the pool");
                return null;
            }
        }

        Cube cube = _cubesQueue.Dequeue();
        cube.transform.position = position;
        cube.SetNumber(number);
        cube.SetColor(GetColor(number));
        cube.gameObject.SetActive(true);

        return cube;
    }

    public Cube SpawnRandom()
    {
        return Spawn(GenerateRandomNumber(), _defaultSpawnPoint);
    }

    public void DestroyCube(Cube cube)
    {
        cube.cubeRigidbody.velocity = Vector3.zero;
        cube.cubeRigidbody.angularVelocity = Vector3.zero;
        cube.transform.rotation = Quaternion.identity;
        cube.isMainCube = false;
        cube.gameObject.SetActive(false);
        _cubesQueue.Enqueue(cube);
    }

    public int GenerateRandomNumber()
    {
        return (int)Mathf.Pow(2, Random.Range(1, 6));
    }

    public Color GetColor(int number)
    {
        return _cubeColors[(int)(Mathf.Log(number) / Mathf.Log(2)) - 1];
    }
}
