using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    public Text soundText;
  

    bool _sound;

    private void Start()
    {
        PlayerPrefs.GetInt("Sound");
    }

    public void SoundButton()
    {
        
        _sound = !_sound;

        if (_sound==true)
        {
            soundText.text = "On";
            PlayerPrefs.SetInt("Sound", 1);
        }

        else
        {
            soundText.text = "Off";
            PlayerPrefs.SetInt("Sound", 0);
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
}
