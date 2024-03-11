using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Slider SoundSlider;
    public string nameOfSeceneToRestart;

    public void UpdateSoundVolume()
    {
        AudioListener.volume = SoundSlider.normalizedValue;
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(nameOfSeceneToRestart);
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
    }

    public void ContinueButtonPressed()
    {
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        Time.timeScale = 0.0f;
    }

    void OnDisable()
    {
        Time.timeScale = 1.0f;
    }
}
