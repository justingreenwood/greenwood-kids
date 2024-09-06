using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonAction : MonoBehaviour
{

    [SerializeField] List<UnityEngine.UI.Button> buttons = new List<UnityEngine.UI.Button>(); 


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        
        

    }

    public void SwitchAllButtons()
    {
        foreach(UnityEngine.UI.Button button in buttons) 
        {
            button.onClick.RemoveAllListeners();
            button.GetComponentInChildren<TextMeshProUGUI>().text= "Yipee";
            button.onClick.AddListener(() => { InterestingChangedAction(1); });
        }
    }
    public void SwitchAllButtonsBack()
    {
        foreach (UnityEngine.UI.Button button in buttons)
        {
            button.onClick.RemoveAllListeners();
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Button";
            button.onClick.AddListener(BoringBeginningAction);
        }
    }

    public void BoringBeginningAction()
    {
        Debug.Log("Button Pressed");
    }

    public void InterestingChangedAction(int i)
    {
        Debug.Log("YAY! It switched." + i);
    }


}
