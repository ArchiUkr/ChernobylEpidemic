using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.SetActive(false);
    }
    public void HandleDeath()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<WeaponsSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
