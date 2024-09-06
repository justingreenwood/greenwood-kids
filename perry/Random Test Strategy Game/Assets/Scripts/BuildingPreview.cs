using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPreview : MonoBehaviour
{
    public LayerMask ground;
    int gridSize = 4;

    [SerializeField] GameObject greenPreview;
    [SerializeField] GameObject redPreview;
    [SerializeField] int width = 8;


    bool blockConstruction = false;
    public bool BlockConstruction {  get { return blockConstruction; } }

    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }


    private void OnCollisionExit(Collision collision)
    {
        blockConstruction = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        blockConstruction = true;
    }

    void Update()
    {

        greenPreview.SetActive(!blockConstruction);
        redPreview.SetActive(blockConstruction);
        BuildingPreviewPlacement();
       
    }

    private void BuildingPreviewPlacement()
    {
        Vector3 groundLocation = Vector3.zero;
        RaycastHit groundHit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out groundHit, Mathf.Infinity, ground))
        {
            groundLocation = groundHit.point;
        }

        if (groundLocation != Vector3.zero)
        {
            Vector3 finalposition = Vector3.zero;
            finalposition.x = Mathf.Floor(groundLocation.x / gridSize) * gridSize;
            finalposition.x += width / 2;
            finalposition.z = Mathf.Floor(groundLocation.z / gridSize) * gridSize;
            finalposition.z += width / 2;

            transform.position = finalposition;
        }
    }
}
