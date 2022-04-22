using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Discord;
using UnityEngine.SceneManagement;
using System;
public class MenuController : MonoBehaviour
{
    public GameObject PlayButton, MusicVol, HowToPlayBack;
    public GameObject mainmenu, optionsmenu, howtoplaymenu, loading;
    public GameObject fpson, fpsoff;
    public GameObject fullon, fulloff;
    public GameObject debugon, debugoff;
    public GameObject vsyncon, vsyncoff;
    public GameObject fpsmodex, debugmodex;
    // Start is called before the first frame update
    private float fps, debugmode, vsync;
    void Start()
    {
        Debug.Log("Loader > MenuController.cs loaded");
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        Debug.Log("FPSCounter.cs > FPS Capped at "+Screen.currentResolution.refreshRate+"! VSync is Enabled");
        if(!PlayerPrefs.HasKey("fps"))
		{
			PlayerPrefs.SetFloat("fps", 0f);
		}
		else
		{
			fps = PlayerPrefs.GetFloat("fps");
			Debug.Log("MenuController.cs > Loaded fps float");
		}
        if(!PlayerPrefs.HasKey("debugmode"))
		{
			PlayerPrefs.SetFloat("debugmode", 0f);
		}
		else
		{
			debugmode = PlayerPrefs.GetFloat("debugmode");
			Debug.Log("MenuController.cs > Loaded debug float");
		}
        if(!PlayerPrefs.HasKey("vsync"))
		{
			PlayerPrefs.SetFloat("vsync", 1f);
            Debug.Log("MenuController.cs > Loaded vsync float");
		}
		else
		{
			vsync = PlayerPrefs.GetFloat("vsync");
			Debug.Log("MenuController.cs > Loaded vsync float");
		}
        fps = PlayerPrefs.GetFloat("fps");
        debugmode = PlayerPrefs.GetFloat("debugmode");
        vsync = PlayerPrefs.GetFloat("vsync");
        if (fps == 1f) {
            fpsoff.SetActive(false);
            fpson.SetActive(true);
            fpsmodex.SetActive(true);
            Debug.Log("FPSCounter.cs > FPS counter on!");
        }
        else
        {
            if (fps == 0f) {
                fpson.SetActive(false);
                fpsoff.SetActive(true);
                fpsmodex.SetActive(false);
                Debug.Log("FPSCounter.cs > FPS counter off!");
            }
        }
        if (debugmode == 1f) {
            debugoff.SetActive(false);
            debugon.SetActive(true);
            debugmodex.SetActive(true);
            Debug.Log("DebugLoader.cs > DebugMode enabled.");
        }
        else
        {
            if (debugmode == 0f) {
                debugon.SetActive(false);
                debugoff.SetActive(true);
                debugmodex.SetActive(false);
                Debug.Log("DebugLoader.cs > DebugMode disabled.");
            }
        }
        if (vsync == 1f) {
            vsyncoff.SetActive(false);
            vsyncon.SetActive(true);
            Debug.Log("GameCore > VSync enabled.");
        }
        else
        {
            if (vsync == 0f) {
                vsyncoff.SetActive(true);
                vsyncon.SetActive(false);
                Debug.Log("GameCore > VSync disabled.");
            }
        }
    }

    IEnumerator LoadGame()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameScene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 3f);
    }
    public void PlayClick()
    {
        GetComponent<AudioManager>().PlaySFX("click");
        Debug.Log("AudioManager.cs > Audioclick sound played.");
    }
    public void PlayBG()
    {
        GetComponent<AudioManager>().Play("background");
        Debug.Log("AudioManager.cs > Audiobackground sound played.");
    }
    public void PlayHover()
    {
        Debug.Log("AudioManager.cs > Audiohover sound played.");
    }
    public void FPSCounter()
    {
        if (fpson.activeSelf) {
            fpson.SetActive(false);
            fpsoff.SetActive(true);
            fpsmodex.SetActive(false);
            Debug.Log("FPSCounter.cs > FPS counter off!");
            PlayerPrefs.SetFloat("fps", 0f);
        }
        else
        {
            if (fpsoff.activeSelf) {
                fpsoff.SetActive(false);
                fpson.SetActive(true);
                fpsmodex.SetActive(true);
                Debug.Log("FPSCounter.cs > FPS counter on!");
                PlayerPrefs.SetFloat("fps", 1f);
            }
        }
    }
    public void FullScreen()
    {
        if (fullon.activeSelf) {
            fullon.SetActive(false);
            fulloff.SetActive(true);
            Screen.SetResolution(1280, 720, false);
            Debug.Log("GameCore > Fullscreen disabled");
        }
        else
        {
            if (fulloff.activeSelf) {
                fullon.SetActive(true);
                fulloff.SetActive(false);
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
                Debug.Log("GameCore > Fullscreen enabled");
            }
        }
    }
    public void DebugMode()
    {
        if (debugon.activeSelf) {
            debugon.SetActive(false);
            debugoff.SetActive(true);
            debugmodex.SetActive(false);
            PlayerPrefs.SetFloat("debugmode", 0f);
            Debug.Log("DebugLoader.cs > Debug mode disabled");
        }
        else
        {
            if (debugoff.activeSelf) {
                debugon.SetActive(true);
                debugoff.SetActive(false);
                debugmodex.SetActive(true);
                PlayerPrefs.SetFloat("debugmode", 1f);
                Debug.Log("DebugLoader.cs > Debug mode enabled");
            }
        }
    }
    public void VSync()
    {
        if (vsyncon.activeSelf) {
            Application.targetFrameRate = 999;
            vsyncon.SetActive(false);
            vsyncoff.SetActive(true);
            Debug.Log("GameCore > FPS uncapped!");

        }
        else
        {
            if (vsyncoff.activeSelf) {
                Application.targetFrameRate = Screen.currentResolution.refreshRate;
                vsyncon.SetActive(true);
                vsyncoff.SetActive(false);
                Debug.Log("GameCore > FPS capped at "+Screen.currentResolution.refreshRate+"!");
            }
        }
    }
    public void PlayGame()
    {
        mainmenu.SetActive(false);
        loading.SetActive(true);
        debugon.SetActive(false);
        fpson.SetActive(false);
        StartCoroutine(LoadGame());
    }
    public void MainMenu()
    {
        mainmenu.SetActive(true);
        optionsmenu.SetActive(false);
        howtoplaymenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(PlayButton);
        Debug.Log("GameCore > Loaded MainMenu");
    }
    public void Options()
    {
        mainmenu.SetActive(false);
        optionsmenu.SetActive(true);
        howtoplaymenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(MusicVol);
        Debug.Log("GameCore > Loaded OptionsMenu");
    }
    public void HowToPlay()
    {
        mainmenu.SetActive(false);
        optionsmenu.SetActive(false);
        howtoplaymenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(HowToPlayBack);
        Debug.Log("GameCore > Loaded HowToPlay");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
