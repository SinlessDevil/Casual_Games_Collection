using UnityEngine;
using System.Collections;

namespace Lesson.Bezier.Curve{
    public class BezierFollow : MonoBehaviour {

        [SerializeField] private Transform[] _routes;

        private int _routeToGo;
        private float _tParam;
        private Vector3 _playerPosition;
        private float _speedModifier;
        private bool coroutineAllowed;

        private void Start(){
            _routeToGo = 0;
            _tParam = 0f;
            _speedModifier = 0.5f;
            coroutineAllowed = true;
        }

        private void Update(){
            if (coroutineAllowed)
                StartCoroutine(GoByTheRoute(_routeToGo));
        }

        private IEnumerator GoByTheRoute(int routeNumber)
        {
            coroutineAllowed = false;

            Vector3 p0 = _routes[routeNumber].GetChild(0).position;
            Vector3 p1 = _routes[routeNumber].GetChild(1).position;
            Vector3 p2 = _routes[routeNumber].GetChild(2).position;
            Vector3 p3 = _routes[routeNumber].GetChild(3).position;

            while(_tParam < 1)
            {
                _tParam += Time.deltaTime * _speedModifier;

                _playerPosition = Mathf.Pow(1 - _tParam, 3) * p0 +
                    3 * Mathf.Pow(1 - _tParam, 2) * _tParam * p1 +
                    3 * (1 - _tParam) * Mathf.Pow(_tParam, 2) * p2 +
                    Mathf.Pow(_tParam, 3) * p3;

                transform.position = _playerPosition;
                yield return new WaitForEndOfFrame();
            }

            _tParam = 0f;
            _routeToGo += 1;

            if (_routeToGo > _routes.Length - 1)
                _routeToGo = 0;

            coroutineAllowed = true;
        }

    }
}

