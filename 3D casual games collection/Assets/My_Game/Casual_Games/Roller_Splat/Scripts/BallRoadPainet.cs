using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallRoadPainet : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private BallMovemant _ballMovemant;
    [SerializeField] private MeshRenderer _ballMeshRenderer;

    public int paintedRoadTiles = 0;

    private void Start()
    {
        //paint ball:
        _ballMeshRenderer.material.color = _levelManager.paintColor;

        //paint default ball tile:
        Paint(_levelManager.defaultBallRoadTile, 0.5f, 0f);
        //.....
        _ballMovemant.OnMoveStart += OnBallMoveStartHandler;
    }

    private void OnBallMoveStartHandler(List<RoadTile> roadTiles, float totalDuration)
    {
        float stepDuration = totalDuration / roadTiles.Count;
        for (int i = 0; i < roadTiles.Count; i++)
        {
            RoadTile roadTile = roadTiles[i];
            if (!roadTile.isPainted)
            {
                AudioManager.Instance.PlayClip(Dictionary.nameAudioClipRollerSplatColorGorund);
                float duration = totalDuration / 2f;
                float delay = i * (stepDuration / 2f);
                Paint(roadTile, duration, delay);

                //Check if Level Completed
                GM_Roller_Splat.Instance.CheckLevelComplited();
            }
        }
    }

    private void Paint(RoadTile roadTile, float duration, float delay)
    {
        roadTile.meshRenderer.material
            .DOColor(_levelManager.paintColor, duration)
            .SetDelay(delay);

        roadTile.isPainted = true;
        paintedRoadTiles++;
        GM_Roller_Splat.Instance.UpdateProgressRollerSplat();
    }
}
