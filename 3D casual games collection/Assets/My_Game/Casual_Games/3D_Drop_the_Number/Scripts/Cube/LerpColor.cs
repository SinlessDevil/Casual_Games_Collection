using UnityEngine;
using System;

public class LerpColor : MonoBehaviour
{
    private MeshRenderer _cubeMeshRenderer;
    [SerializeField] [Range(0f, 1f)] private float _lerpTime;

    [SerializeField] private Color[] _color;

    private int _colorIndex = 0;
    private float _time = 0f;
    private int _len;

    private void Start()
    {
        _cubeMeshRenderer = GetComponent<MeshRenderer>();
        _len = _color.Length;
    }

    private void Update()
    {
        _cubeMeshRenderer.material.color = Color.Lerp(_cubeMeshRenderer.material.color, _color[_colorIndex], _lerpTime * Time.deltaTime);

        _time = Mathf.Lerp(_time, 1f, _lerpTime * Time.deltaTime);
        if(_time > .9f)
        {
            _time = 0f;
            _colorIndex++;
            _colorIndex = (_colorIndex >= _len) ? 0 : _colorIndex;
        }
    }
}
