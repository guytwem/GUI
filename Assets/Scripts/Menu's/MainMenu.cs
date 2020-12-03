using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class MainMenu : MonoBehaviour //this is the class of code that is called for Main Menu
{
    #region Public variables
    
    public Dropdown qualityDropdown;
    public Toggle fullscreenToggle;
    public AudioMixer mixer;
    public Slider musicSlider;
    public Slider SFXSlider;
    
    #endregion

    public void Awake()
    {
        LoadPlayerPrefs();
    }

    public void Start()
    {
        Debug.Log("Starting game main menu"); // This is the first code called and logs the start of the game menu

        if (!PlayerPrefs.HasKey("fullscreen"))
        {
            PlayerPrefs.SetInt("fullscreen", 0);
            Screen.fullScreen = false; // this starts in windowed, change to true and 1 for fullscreen start
        }
        else
        {
            if (PlayerPrefs.GetInt("fullscreen") == 0)
            {
                Screen.fullScreen = false;
            }
            else
            {
                Screen.fullScreen = true;
            }
        }

        if (!PlayerPrefs.HasKey("quality"))
        {
            PlayerPrefs.SetInt("Quality", 4);
            QualitySettings.SetQualityLevel(4);
        }
        else
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        }

        PlayerPrefs.Save();

        
    }

    public Image progressBar;
    public Text progressBarText;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);

            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.fillAmount = progress;
            progressBarText.text = Mathf.RoundToInt(progress * 100) + "%";



            yield return null;
        }
    }


    public void SetFullScreen(bool fullscreen) // for entering full screen and exiting
    {
        Screen.fullScreen = fullscreen;
    }

    public void ChangeQuality(int index) // sets quality settings of the dropdown box
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void QuitGame() // this is our quit game function
    {
        Debug.Log("Quitting Game"); // Logs when the exit button is pressed
#if UNITY_EDITOR // This will quit playmode when we are in the game and the exit button is pressed
        EditorApplication.ExitPlaymode();
#endif 
        Application.Quit();

    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("MusicVol", value);
    }

    public void SetSFXVolume(float value)
    {
        mixer.SetFloat("SFXVol", value);
    }

    

    #region save and load player prefs
    public void SavePlayerPrefs() // saves player preferences for next load
    {
        PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());

        if (fullscreenToggle.isOn)
        {
            PlayerPrefs.SetInt("fullscreen", 1); // 1 is bool for true
        }
        else
        {
            PlayerPrefs.SetInt("fullscreen", 0); // 0 bool for false
        }

        float musicVol;
        if (mixer.GetFloat("MusicVol", out musicVol))
        {
            PlayerPrefs.SetFloat("MusicVol", musicVol);
        }
        float SFXVol;
        if (mixer.GetFloat("SFXVol", out SFXVol))
        {
            PlayerPrefs.SetFloat("SFXVol", SFXVol);
        }


        PlayerPrefs.Save();
    }

    public void LoadPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("quality"))
        {
            int quality = PlayerPrefs.GetInt("quality");
            qualityDropdown.value = quality;
            if (QualitySettings.GetQualityLevel() != quality)
            {
                ChangeQuality(quality);
            }
        }

        if (PlayerPrefs.HasKey("fullscreen"))
        {
            if (PlayerPrefs.GetInt("fullscreen") == 0)
            {
                fullscreenToggle.isOn = false;// set gui toggle off
            }
            else
            {
                fullscreenToggle.isOn = true; //set gui toggle on
            }
        }
        //load audio sliders
        if (PlayerPrefs.HasKey("MusicVol"))
        {
            float musicVol = PlayerPrefs.GetFloat("MusicVol");
            musicSlider.value = musicVol;
            mixer.SetFloat("MusicVol", musicVol);
        }
        if (PlayerPrefs.HasKey("SFXVol"))
        {
            float SFXVol = PlayerPrefs.GetFloat("SFXVol");
            SFXSlider.value = SFXVol;
            mixer.SetFloat("SFXVol", SFXVol);
        }
    }

    #endregion


    public void OnGUI() // When unity processes the GUI this is called
    {
        GUI.Box(new Rect(10, 10, 100, 120), "Testing Box"); // Adds and positions a box, Rect(x,y,width,height)
        
        
        if(GUI.Button(new Rect(20,40,80,20), "Press me")) // positions and adds a press me button to the gui
        {
            Debug.Log("Press me button got pressed"); // logs when the button is pressed
        }

        if (GUI.Button(new Rect(20, 70, 80, 20), "Press me 2")) // positions and adds a press me button to the gui
        {
            Debug.Log("Press me 2 button got pressed"); // logs when the button is pressed
            QuitGame();
        }

     
    }
}
