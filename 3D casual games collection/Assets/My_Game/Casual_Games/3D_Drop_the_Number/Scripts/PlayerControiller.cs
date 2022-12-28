using UnityEngine;

public class PlayerControiller : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _cudeMaxPosX;
    [Space(20)]
    [SerializeField] private TouchedSider _touchedSlider;

    private Cube _mainCube;

    private bool _isPointerDown;
    private bool _canMove;
    private Vector3 _cubePos;

    private void Start()
    {
        SpawnCube();
        _canMove = true;

        //Lister to Slider events
        _touchedSlider.OnPointerDownEvent += OnPointerDown;
        _touchedSlider.OnPointerDragEvent += OnPointerDrag;
        _touchedSlider.OnPointerUpEvent += OnPointerUp;
    }

    private void Update()
    {
        if (_isPointerDown)
        {
            _mainCube.transform.position = Vector3.Lerp(
                _mainCube.transform.position,
                _cubePos,
                _moveSpeed * Time.deltaTime
                );

        }
    }

    private void OnPointerDown(){
        _isPointerDown = true;
    }

    private void OnPointerDrag(float xMovement){
        if (_isPointerDown)
        {
            _cubePos = _mainCube.transform.position;
            _cubePos.x = xMovement * _cudeMaxPosX;
        }
    }

    private void OnPointerUp(){
        if (_isPointerDown && _canMove)
        {
            _isPointerDown = false;
            _canMove = false;

            //Push the cube
            _mainCube.cubeRigidbody.AddForce(Vector3.forward * _pushForce, ForceMode.Impulse);

            Invoke("SpawnNewCube", 0.3f);
        }
    }

    private void SpawnNewCube()
    {
        _mainCube.isMainCube = false;
        _canMove = true;
        SpawnCube();
    }

    private void SpawnCube()
    {
        _mainCube = CubeSpawner.Instance.SpawnRandom();
        _mainCube.isMainCube = true;

        //reset cubePos variabls
        _cubePos = _mainCube.transform.position;
    }

    private void OnDestroy()
    {
        //remove listeners:
        _touchedSlider.OnPointerDownEvent -= OnPointerDown;
        _touchedSlider.OnPointerDragEvent -= OnPointerDrag;
        _touchedSlider.OnPointerUpEvent -= OnPointerUp;
    }
}
