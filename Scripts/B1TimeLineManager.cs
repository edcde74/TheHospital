using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class B1TimeLineManager : MonoBehaviour
{
    public PlayableDirector B1playerDirector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartTimeLine();
    }

    public void StartTimeLine()
    {
        if (Enemy.killing)
        {
            Debug.Log("타임라인");
            B1playerDirector.Play();
            Enemy.killing = false;
        }
        
    }

    public void Quit()
    {
        GameManager.Instance.Quit();
    }

    public void GoToLobby()
    {
        StartCoroutine(LodingScene.Instance.LoadSceneFade(0));
    }
}
