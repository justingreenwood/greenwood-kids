using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameOverCanvas.enabled = false;

    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled=true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwap>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}
