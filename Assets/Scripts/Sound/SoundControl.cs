using UnityEngine;

public class SoundControl : MonoBehaviour
{
    AudioSource _audio;

    [SerializeField]
    AudioClip _clip;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Sound")==0)
        {
            _audio.enabled = false;
        }
        else
        {
            _audio.enabled = true;
        }
    }

    public void DeadSoundPlay()
    {
        if (_audio.enabled==true)
        {
            _audio.Stop();
            _audio.PlayOneShot(_clip);
        }
    }
}
