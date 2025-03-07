using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceDisplay : MonoBehaviour
{
    PlayerController playerController;
    ResourceBank resourceBank;
    TMP_Text textDisplay;
    string text;

    void Start()
    {
        
        playerController = FindObjectOfType<PlayerController>();
        resourceBank = playerController.gameObject.GetComponent<ResourceBank>();
        textDisplay = GetComponent<TMP_Text>();

        text = $"Wood: {resourceBank.Wood} Food: {resourceBank.Food} Gems: {resourceBank.Gems} Units: {playerController.unitsAlive}/{resourceBank.UnitLimit}";

    }


    void Update()
    {
       
        textDisplay.text = $"Wood: {resourceBank.Wood} Food: {resourceBank.Food} Gems: {resourceBank.Gems} Units: {playerController.unitsAlive}/{resourceBank.UnitLimit}";


    }
}
