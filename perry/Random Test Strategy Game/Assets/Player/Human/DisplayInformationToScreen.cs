using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class DisplayInformationToScreen : MonoBehaviour
{
    [SerializeField] Canvas SUCanvas;
    [SerializeField] UnityEngine.UI.Image unitImage;
    [SerializeField] TextMeshProUGUI nameDisplay;
    [SerializeField] TextMeshProUGUI healthDisplay;
    [SerializeField] TextMeshProUGUI armorDisplay;
    [SerializeField] TextMeshProUGUI damageDisplay;

    [SerializeField] UnityEngine.UI.Button[] buildQueueButtons;


    public void DisplayUnitInfo(GuyMovement unit)
    {
        unitImage.sprite = unit.unitImage;
        nameDisplay.text = unit.unitType.ToString();
        healthDisplay.text = $"Health: {unit.currentHealth}/{unit.maxHealth}";
        armorDisplay.text = $"Armor: {unit.armor+ unit.bonusArmor}";
        damageDisplay.text = $"Damage: {unit.attackDamage+ unit.bonusAttackDamage}";
        SUCanvas.enabled = true;
    }
    public void EditUnitInfo(float health, float maxHealth)
    {
        healthDisplay.text = $"Health: {health}/{maxHealth}";
    }


    public void ResetDisplay()
    {
        unitImage.sprite = null;
        nameDisplay.text = null;
        healthDisplay.text = null;
        armorDisplay.text = null;
        SUCanvas.enabled = false;
        foreach(var button in buildQueueButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

}
