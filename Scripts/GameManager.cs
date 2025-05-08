using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ui;
    private static GameManager gameManager = null;
    public GameObject shakingButton;
    public Sprite[] camearaShaking;
    public static bool camearaShakingChaeck;
    public bool settingOn;
    public bool isGamePlay;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (gameManager == null)
        {
            gameManager = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        
    }

    void Start()
    {
        camearaShakingChaeck = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (settingOn && Input.GetKeyDown(KeyCode.Escape))
        {
            SettingOff();
        }
       // Debug.Log("타임 스케일 : " + Time.timeScale);
       // Debug.Log("isOn : " + EscUI.isOn);
    }

    public static GameManager Instance
    {
        get
        {
            if (null == gameManager)
            {
                return null;
            }
            return gameManager;
        }
    }

    public void ChangeShaking()
    {
        shakingButton = GameObject.FindGameObjectWithTag("SkBu");
        camearaShakingChaeck = !camearaShakingChaeck;
        if (camearaShakingChaeck)
        {
            shakingButton.GetComponent<Image>().sprite = camearaShaking[1];
        }
        else
        {
            shakingButton.GetComponent<Image>().sprite = camearaShaking[0];
        }
    }

    public void SettingOn()
    {
        ui = GameObject.FindGameObjectWithTag("Press");
        if (!settingOn)
        {
            settingOn = true;
                for(int i = 0; i < ui.transform.childCount; i++)
                {   

                 ui.transform.GetChild(i).gameObject.SetActive(true);

                }
            shakingButton = GameObject.FindGameObjectWithTag("SkBu");
        }
        
    }

    public void SettingOff()
    {
        ui = GameObject.FindGameObjectWithTag("Press");
        settingOn = false;
        for (int i = 0; i < ui.transform.childCount; i++)
        {
            ui.transform.GetChild(i).gameObject.SetActive(false);
        }
       
    }

    public void Quit()
    {
        Application.Quit();
    }

}
