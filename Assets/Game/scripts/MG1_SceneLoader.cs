using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Extension para manejar escenas

public class MG1_SceneLoader : MonoBehaviour
{
    public void LevelChanger(string _levelToLoad)
    {
        SceneManager.LoadScene(_levelToLoad);
    }
}
