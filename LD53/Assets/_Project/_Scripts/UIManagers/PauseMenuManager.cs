using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private KeyCode _pauseMenuKey;
    [SerializeField] private GameObject _pauseMenu;

    [SerializeField] private CameraLook _cameraLook;
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private Slider _sensetivitySlider;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private Slider _musicSlider;

    private float _timeScale;

    private void Awake()
    {
        _pauseMenu.SetActive(true);
        //OnSFXUpdate(PlayerPrefs.GetFloat("SFXVolume"));
        //OnVolumeUpdate(PlayerPrefs.GetFloat("MusicVolume"));
        //OnSensetivityUpdate(PlayerPrefs.GetFloat("lookSpeed"));

        _sensetivitySlider.value = PlayerPrefs.GetFloat("lookSpeed");
        _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        //_musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        if (_pauseMenu.activeSelf)
        {
            ToggleMenu();
        }
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_pauseMenuKey))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        _pauseMenu.SetActive(!_pauseMenu.activeSelf);
        if (_pauseMenu.activeSelf) 
        {
            Cursor.lockState = CursorLockMode.None;
            _timeScale = Time.timeScale;
            Time.timeScale = 0;
        } 
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = _timeScale;
        }
    }
    
    public void OnSensetivityUpdate(float value)
    {
        _cameraLook.SetLookSpeed((value + .3f) * 2);
        PlayerPrefs.SetFloat("lookSpeed", value);
    }
    public void OnSFXUpdate(float value)
    {
        if (value == 0) _audioMixer.SetFloat("SFXVolume", -80);
        else _audioMixer.SetFloat("SFXVolume", Mathf.Lerp(-40, 20, value));
        PlayerPrefs.SetFloat("SFXVolume", value);

    }
    public void OnVolumeUpdate(float value)
    {
        if (value == 0) _audioMixer.SetFloat("MusicVolume", -80);
        else _audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-40, 20, value));
        PlayerPrefs.SetFloat("MusicVolume", value);

    }


    public void ExitGame()
    {
        Application.Quit();
    }

    
}
