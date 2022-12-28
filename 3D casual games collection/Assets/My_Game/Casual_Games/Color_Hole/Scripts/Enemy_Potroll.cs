using UnityEngine;

public class Enemy_Potroll : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _waitTime;
    [SerializeField] private float startWaitTime;

    [SerializeField] private Transform[] _moveSpots;
    private int _randomSpot;

    private void Start()
    {
        _waitTime = startWaitTime;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _moveSpots[_randomSpot].position, _speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, _moveSpots[_randomSpot].position) < 0.01f){
            if (_waitTime <= 0){
                _randomSpot = Random.Range(0, _moveSpots.Length);
                _waitTime = startWaitTime;
            }else{
                _waitTime -= Time.deltaTime;
            }
        }
    }
}
