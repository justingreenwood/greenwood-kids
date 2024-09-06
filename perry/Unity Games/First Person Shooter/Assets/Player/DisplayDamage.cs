using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{

    [SerializeField] Canvas damageDisplay;
    [SerializeField] float displayLength = 0.5f;


    void Start()
    {
        damageDisplay.enabled = false;
    }

    public void PaintDamage()
    {
        StartCoroutine(PaintDamageOnScreen());
    }

    IEnumerator PaintDamageOnScreen()
    {
        damageDisplay.enabled = true;
        yield return new WaitForSeconds(displayLength);
        damageDisplay.enabled = false;
    }

}
