using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MenuController : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject MusicVol;
    public GameObject HowToPlayBack;
    public GameObject mainmenu;
    public GameObject optionsmenu;
    public GameObject howtoplaymenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClick()
    {

    }
    public void PlayHover()
    {

    }
    public void MainMenu()
    {
        mainmenu.SetActive(true);
        optionsmenu.SetActive(false);
        howtoplaymenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(PlayButton);
    }
    public void Options()
    {
        mainmenu.SetActive(false);
        optionsmenu.SetActive(true);
        howtoplaymenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(MusicVol);
    }
    public void HowToPlay()
    {
        mainmenu.SetActive(false);
        optionsmenu.SetActive(false);
        howtoplaymenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(HowToPlayBack);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
