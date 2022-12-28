using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HoleMovemant : MonoBehaviour{

    public enum TypePlatfrom{
        PC,
        Smartphone
    }

    public TypePlatfrom typePlatform;

    [Space]
    [Header("Hole mesh")]
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshCollider meshCollider;

    [Header("Hole vertices radius")]
    [SerializeField] private  Vector2 moveLimits;
    //Hole vertices radius from the hole's center
    [SerializeField] private float radius;
    [SerializeField] private Transform holeCenter;

    [Space]
    [SerializeField] private float moveSpeed;

    private Mesh mesh;
    private List<int> holeVertices;
    //hole vertices offsets from hole center
    private List<Vector3> offsets;
    private int holeVerticesCount;

    private float x, y;
    private Vector3 touch, targetPos;

    private void Start(){

        GameManagerHoleVsColor.isGameover = false;
        GameManagerHoleVsColor.isMoving = false;

        //Initializing lists
        holeVertices = new List<int>();
        offsets = new List<Vector3>();

        //get the meshFilter's mesh
        mesh = meshFilter.mesh;

        //Find Hole vertices on the mesh
        FindHoleVertices();
    }

    private void Update(){
        switch (typePlatform){
            case TypePlatfrom.PC:
                //Mouse

                //isMoving=true whenever mouse is clicked 
                //isMoving=falseever mouse is released
                GameManagerHoleVsColor.isMoving = Input.GetMouseButton(0);
                if (!GameManagerHoleVsColor.isGameover && GameManagerHoleVsColor.isMoving){
                    //Move hole center
                    MoveHole();
                    //Update hole vertices
                    UpdateHoleVerticesPosition();
                }
                break;
            case TypePlatfrom.Smartphone:
                //Touch

                //TouchPhase.Moved to prevent hole from jumping at first touch
                GameManagerHoleVsColor.isMoving = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved;
                if (!GameManagerHoleVsColor.isGameover && GameManagerHoleVsColor.isMoving){
                    //Move hole center
                    MoveHole();
                    //Update hole vertices
                    UpdateHoleVerticesPosition();
                }
                break;
        }
    }

    private void MoveHole(){
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        //lerp (smooth) movement
        touch = Vector3.Lerp(
            holeCenter.position,
            holeCenter.position + new Vector3(x, 0f, y), //move hole on x & z 
            moveSpeed * Time.deltaTime
        );

        targetPos = new Vector3(
            //Clamp: to prevent hole from going outside of the ground
            Mathf.Clamp(touch.x, -moveLimits.x, moveLimits.x),//limit X
            touch.y,
            Mathf.Clamp(touch.z, -moveLimits.y, moveLimits.y)//limit Z
        );

        holeCenter.position = targetPos;
    }

    private void UpdateHoleVerticesPosition(){
        //Move hole vertices
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < holeVerticesCount; i++){
            vertices[holeVertices[i]] = holeCenter.position + offsets[i];
        }

        //update mesh vertices
        mesh.vertices = vertices;
        //update meshFilter's mesh
        meshFilter.mesh = mesh;
        //update collider
        meshCollider.sharedMesh = mesh;
       // Debug.Log("Update");
    }

    private void FindHoleVertices(){
        for (int i = 0; i < mesh.vertices.Length; i++){
            //Calculate distance between holeCenter & each Vertex
            float distance = Vector3.Distance(holeCenter.position, mesh.vertices[i]);

            if (distance < radius){
                //this vertex belongs to the Hole
                holeVertices.Add(i);
                //offset: how far the Vertex from the HoleCenter
                offsets.Add(mesh.vertices[i] - holeCenter.position);
            }
        }
        //save hole vertices count
        holeVerticesCount = holeVertices.Count;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(holeCenter.position, radius);
    }
}
