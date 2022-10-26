using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prefs : MonoBehaviour
{
    [SerializeField]
    private Toggle activar_Musica;
    [SerializeField]
    private AudioSource musica;

    public void Awake()
    {
        if(!PlayerPrefs.HasKey("musica"))
        {
            PlayerPrefs.SetInt("musica", 1);
            activar_Musica.isOn = true;
            musica.enabled = true;
            PlayerPrefs.Save();
        }
        else 
        {
            if(PlayerPrefs.GetInt("music") == 0)
            {
                activar_Musica.isOn = false;
                musica.enabled = false;
            }
            else
            {
                activar_Musica.isOn = true;
                musica.enabled = true;
            }
        }
    }

    public void ToggleMusic()
    {
        if(activar_Musica.isOn)
        {
            PlayerPrefs.SetInt("musica", 1);
            musica.enabled = true;
        }
        else
        {
            PlayerPrefs.SetInt("musica", 0);
            musica.enabled = false;
        }
        PlayerPrefs.Save();
    }
}
