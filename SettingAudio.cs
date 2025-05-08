using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SettingAudio : MonoBehaviour
{
    [SerializeField]
    private static SettingAudio audioManager = null;
    [SerializeField]
    private Slider soundControl;
    [SerializeField]
    private TextMeshProUGUI soundNow;
    public Sprite[] audioSprite;
    [SerializeField]
    private Button soundButton;
    public bool noSound;
   
    public static float sound = 1f;

    // Start is called before the first frame update
    private void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        

    }
    public static SettingAudio Instance
    {
        get
        {
            if (null == audioManager)
            {
                return null;
            }
            return audioManager;
        }
    }
    void Start()
    {
        GameManager.Instance.SettingOn();
        soundControl = GameObject.FindGameObjectWithTag("SoundCon").GetComponent<Slider>();
        soundNow = GameObject.FindGameObjectWithTag("SoundText").GetComponent<TextMeshProUGUI>();
        soundButton = GameObject.FindGameObjectWithTag("NoSound").GetComponent<Button>();
        sound = PlayerPrefs.GetFloat("sound", sound);
        soundControl.value = sound;
        AudioListener.volume = soundControl.value;
        GameManager.Instance.SettingOff();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        AudioListener.volume = PlayerPrefs.GetFloat("sound", sound);
    }

    public void SoundControllor()
    {
        soundControl = GameObject.FindGameObjectWithTag("SoundCon").GetComponent<Slider>();
        AudioListener.volume = PlayerPrefs.GetFloat("sound");
        sound = soundControl.value;
        soundControl.value = sound;
        PlayerPrefs.SetFloat("sound", sound );
    }

    public void SliderControl()
    {
        soundNow = GameObject.FindGameObjectWithTag("SoundText").GetComponent<TextMeshProUGUI>();
        soundNow.text = "Now Sound : " + soundControl.value.ToString();
    }

   public void ChangeSprite()
    {
        soundButton = GameObject.FindGameObjectWithTag("NoSound").GetComponent<Button>();
        if (soundControl.value == 0)
        {
            soundButton.GetComponent<Image>().sprite = audioSprite[1];
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = audioSprite[0];
        }
        
    }

    public void NoSound()
    {
        soundControl.value = 0;
    }
}
