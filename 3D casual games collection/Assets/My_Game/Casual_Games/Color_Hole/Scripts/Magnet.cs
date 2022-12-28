using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Magnet : MonoBehaviour
{
    #region Singleton class: UIManager

    public static Magnet Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    #endregion

    [SerializeField] private float _magnetForce;

    private List<Rigidbody> _affectedRigidbodies = new List<Rigidbody>();
    private Transform _magnet;

    private void Start()
    {
        _magnet = transform;
        _affectedRigidbodies.Clear();
    }

    private void FixedUpdate(){
        if(!GameManagerHoleVsColor.isGameover && GameManagerHoleVsColor.isMoving){
            foreach (Rigidbody rb in _affectedRigidbodies){
                rb.AddForce((_magnet.position - rb.position) * _magnetForce * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        if(!GameManagerHoleVsColor.isGameover && (tag.Equals(Dictionary.nameTagObstacle) || tag.Equals(Dictionary.nameTagObject)))
        {
            AddToMagnetField(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        string tag = other.tag;

        if (!GameManagerHoleVsColor.isGameover && (tag.Equals(Dictionary.nameTagObstacle) || tag.Equals(Dictionary.nameTagObject)))
        {
            RemoveFromMagnetField(other.attachedRigidbody);
        }
    }

    public void AddToMagnetField(Rigidbody rb)
    {
        _affectedRigidbodies.Add(rb);
    }

    public void RemoveFromMagnetField(Rigidbody rb)
    {
        _affectedRigidbodies.Remove(rb);
    }
}
