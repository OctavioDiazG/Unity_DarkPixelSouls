using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour 
{   
    public string nextLevelName;

    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextLevelName);
            //GoToNextLevel();
        }
    }
    
    /*
    void OnTriggerEnter2D (Collision2D other)
    {
        SceneManager.LoadScene(nextLevelName);
    }
    */

    public virtual void GoToNextLevel()
    {
        //loadingImage.SetActive(true);
        SceneManager.LoadScene(nextLevelName);

    }


}