using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    RaycastHit hit;
    List<Transform> selectedUnits = new List<Transform>();

    const int leftMouseButton = 0;
    const int rightMouseButton = 1;
    void Update()
    {
        

        if (Input.GetMouseButtonDown(leftMouseButton))
        {

            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(camRay, out hit))
            {
                if(hit.transform.CompareTag("Unit"))
                {
                    SelectUnit(hit.transform);
                }
                else if (hit.transform.CompareTag("Ground"))
                {
                    DeselectUnits();
                }
                Debug.Log(selectedUnits.Count);
            }
            Dragger dragger = new Dragger();

        }
        
    }

    void DeselectUnits()
    {
        selectedUnits.Clear();
    }
    void SelectUnit(Transform hit)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            DeselectUnits();
        }
        if(!selectedUnits.Contains(hit.transform))
            selectedUnits.Add(hit);
    }
}
