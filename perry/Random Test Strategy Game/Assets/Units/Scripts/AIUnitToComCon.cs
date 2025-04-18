using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIUnitToComCon : MonoBehaviour
{
    ComputerController computerController;
    GuyMovement guyMovement;
    void Start()
    {
        computerController = GetComponentInParent<ComputerController>();
        guyMovement = GetComponent<GuyMovement>();
    }

    void Update()
    {
        if (computerController != null)
        {
            if (guyMovement.currentAction == UnitActions.Nothing)
            {
                computerController.GetJob(guyMovement);
            }
        }
        
    }
}
