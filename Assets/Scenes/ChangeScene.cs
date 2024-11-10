using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
