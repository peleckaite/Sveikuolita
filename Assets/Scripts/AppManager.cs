using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject currentScreen;

    void Start()
    {
        menuScreen = currentScreen;
    }

    #region On Button Click receivers
    public void CallPhone(Object obj)
    {
        var phoneTxt = (obj as GameObject).GetComponent<Text>().text;
        Application.OpenURL("tel://" + phoneTxt);
    }

    public void BackButtonClick()
    {
        SwitchScreen(menuScreen);
    }

    public void MenuButtonClick(Object screenToAcivate)
    {
        GameObject screen = screenToAcivate as GameObject;
        SwitchScreen(screen);
    }
    #endregion

    void SwitchScreen(GameObject screen)
    {
        if (currentScreen != null)  
        { 
            currentScreen.SetActive(false);
        }
            
        screen.SetActive(true);
        currentScreen = screen;
    }
}
