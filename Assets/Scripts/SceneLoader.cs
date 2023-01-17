using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void ReloadScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        
    }
}
