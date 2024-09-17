using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class DisplayInformationToScreen : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] UnityEngine.UI.Image unitImage;
    [SerializeField] TextMeshProUGUI nameDisplay;
    [SerializeField] TextMeshProUGUI healthDisplay;
    [SerializeField] TextMeshProUGUI armorDisplay;
    [SerializeField] TextMeshProUGUI damageDisplay;

    [SerializeField] UnityEngine.UI.Button[] buildQueueButtons;


    public void DisplayUnitInfo(GuyMovement unit)
    {
        unitImage.sprite = unit.unitImage;
        nameDisplay.text = unit.name;
        healthDisplay.text = $"Health: {unit.CurrentHealth}/{unit.MaxHealth}";
        armorDisplay.text = $"Armor: {unit.Armor}";
        damageDisplay.text = $"Damage: {unit.AttackDamage}";
        canvas.enabled = true;
    }
    public void EditUnitInfo(int health, int maxHealth)
    {
        healthDisplay.text = $"Health: {health}/{maxHealth}";
    }


    public void ResetDisplay()
    {
        unitImage.sprite = null;
        nameDisplay.text = null;
        healthDisplay.text = null;
        armorDisplay.text = null;
        canvas.enabled = false;
        foreach(var button in buildQueueButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

}
