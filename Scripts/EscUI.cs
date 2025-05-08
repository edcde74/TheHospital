using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EscUI : MonoBehaviour
{
    public static bool isOn;
    public static bool isSettingOn;
    public GameObject setting;

    // Update is called once per frame
    void Update()
    {
       if(!(SceneManager.GetActiveScene().buildIndex == 3))
        {
            
            PressESC();
            GameStop();
        }
        
    }

    void PressESC()
    {
        
            if (setting.activeSelf == true)
            {
                if (PlayTimeLine.isGamePlay&&
                Input.GetKeyDown(KeyCode.Escape))
                {
                    setting.SetActive(false);
                }

            }
            else
            {
                if (PlayTimeLine.isGamePlay &&
                Input.GetKeyDown(KeyCode.Escape) && !isOn)
                {
                    SetOn();

                }
                else if (isOn && Input.GetKeyDown(KeyCode.Escape))
                {
                    SetOff();

                }
            }
       
    }

    public void BackGame()
    {
        SetOff();
    }

    public void OnSetting()
    {
        isSettingOn = true;
        setting.SetActive(true);
    }
    public void OffSetting()
    {
        isSettingOn = false;
        setting.SetActive(false);
    }
    void SetOn()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        isOn = true;
    }

    public void SetOff()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        isOn = false;
    }

    void GameStop()
    {
        if (isOn)
        {
            Time.timeScale = 0;
        }
        else if(!isOn)
        {
            Time.timeScale = 1;
        }
    }

    public void GameQuit()
    {
        GameManager.Instance.Quit();
    }

    public void BackLobby()
    {
        //SceneManager.LoadScene(0);
        SetOff();
        PlayTimeLine.isGamePlay = false;
       StartCoroutine(LodingScene.Instance.LoadSceneFade(0));
        
    }

    
}
