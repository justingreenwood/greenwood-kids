using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPNonUIVisAid : MonoBehaviour
{

    TextMeshPro tMP;

    [SerializeField] int size = 20;
    [SerializeField] GameObject unitGO;

    public int Size {  get { return size; } }

    void Awake()
    {
        tMP = GetComponentInChildren<TextMeshPro>();
    }
    private void Update()
    {

    }
    public void EditTMP(float currentHealth, float maxHealth)
    {
        string text = "";
        float healthBySize = maxHealth/size;

        for(int i = 1; i <= size; i++)
        {
            if (currentHealth >= healthBySize*i)
            {
                text += "N";
            }
            else
            {
                break;
            }
        }
        
        if(currentHealth < healthBySize)
        {
            text = "N";
            tMP.color = Color.red;
        }
        else if (currentHealth <= maxHealth / 4)
        {
            tMP.color = new Color32(0xFF, 0x66, 0x00, 0xFF);
        }
        else if (currentHealth <= maxHealth / 2)
        {
            tMP.color = Color.yellow;
        }
        tMP.text = text;

    }

}
