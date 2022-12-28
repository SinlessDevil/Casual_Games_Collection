using UnityEngine;

namespace Lesson.Bezier.Curve{
    public class Rout : MonoBehaviour {

        [SerializeField] private Transform[] _conrtolPoints;

        private Vector3 _gizmosPosition;

        private void OnDrawGizmos()
        {
            for (float i = 0; i <= 1; i += 0.05f)
            {
                _gizmosPosition = Mathf.Pow(1 - i, 3) * _conrtolPoints[0].position +
                    3 * Mathf.Pow(1 - i, 2) * i * _conrtolPoints[1].position +
                    3 * (1 - i) * Mathf.Pow(i, 2) * i * _conrtolPoints[2].position +
                    Mathf.Pow(i, 3) * _conrtolPoints[3].position;

                Gizmos.DrawSphere(_gizmosPosition, 0.10f);
            }

         /*   Gizmos.DrawLine(new Vector3(_conrtolPoints[0].position.x, _conrtolPoints[0].position.y),
                new Vector3(_conrtolPoints[1].position.x, _conrtolPoints[1].position.y));

            Gizmos.DrawLine(new Vector3(_conrtolPoints[2].position.x, _conrtolPoints[2].position.y),
                new Vector3(_conrtolPoints[3].position.x, _conrtolPoints[3].position.y));
        */
        }
    }
}