using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public void BackToTheLobby()
    {
        SceneManager.LoadScene("Stefan");
    }

    public void GoToTheVerfmachine()
    {
        SceneManager.LoadScene("Verfmachine");
    }
}
