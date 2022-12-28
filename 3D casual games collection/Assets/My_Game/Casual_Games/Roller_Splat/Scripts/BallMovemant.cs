using UnityEngine;
using GG.Infrastructure.Utils.Swipe;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.Events;

// added this line to sort tiles by distance from the ray's origin using LINQ Queries  ( Line 50 & 51 ):
using System.Linq;

public class BallMovemant : MonoBehaviour
{
    [SerializeField] private SwipeListener _swipeListener;
    [SerializeField] private LevelManager _levelManager;

    [SerializeField] private float _stepDuration = 0.1f;
    [SerializeField] private LayerMask _wallsAndRoadsLayer;
    private const float MAX_RAY_DISTANCE = 100f;

    public UnityAction<List<RoadTile>, float> OnMoveStart;

    private Vector3 _moveDirection;
    private bool _canMove = true;

    private void Start(){
        //change default ball position :
        transform.position = _levelManager.defaultBallRoadTile.position;

        _swipeListener.OnSwipe.AddListener(swipe =>{
            switch (swipe)
            {
                case "Right":
                    _moveDirection = Vector3.right;
                    break;
                case "Left":
                    _moveDirection = Vector3.left;
                    break;
                case "Up":
                    _moveDirection = Vector3.forward;
                    break;
                case "Down":
                    _moveDirection = Vector3.back;
                    break;
            }
            Debug.Log(swipe);
            MoveBall();
        });
    }

    private void MoveBall(){
        if (_canMove){
            AudioManager.Instance.PlayClip(Dictionary.nameAudioClipRollerSplatMove);
            _canMove = false;
            // add raycast in the swipe direction (from the ball) :
            RaycastHit[] hits = Physics.RaycastAll(transform.position, _moveDirection, MAX_RAY_DISTANCE, _wallsAndRoadsLayer.value)
                                       .OrderBy(hit => hit.distance).ToArray(); // added this line to sort tiles by distance from the ray's origin

            Vector3 targetPosition = transform.position;

            int steps = 0;

            List<RoadTile> pathRoadTiles = new List<RoadTile>();

            for (int i = 0; i < hits.Length; i++){
                if (hits[i].collider.isTrigger){ // Road tile
                    // add road tiles to the list to be painted:
                    pathRoadTiles.Add(hits[i].transform.GetComponent<RoadTile>());

                }else{ // Wall tile
                    if(i == 0){ // means wall is near the ball
                        _canMove = true;
                        return;
                    }
                    //else:
                    steps = i;
                    targetPosition = hits[i - 1].transform.position;
                    break;
                }
            }

            //move the ball to targetPosiiton
            float moveDuration = _stepDuration * steps;
            transform
                .DOMove(targetPosition, moveDuration)
                .SetEase(Ease.OutExpo)
                .OnComplete(() => _canMove = true);

            if (OnMoveStart != null)
                OnMoveStart.Invoke(pathRoadTiles, moveDuration);
        }
    }
}
