using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LodingLoop : MonoBehaviour
{
    
    public Sprite[] lodingBar;
    public int index;

    private void Update()
    {
        LodingBarLoop();
    }

    void LodingBarLoop()
    {
        gameObject.GetComponent<Image>().sprite = lodingBar[index];
        StartCoroutine(Loop());
        
          
    }
    
    IEnumerator Loop()
    {
        if(index <= 4)
        {
            index = 0;
        }
        else
        {
            index++;
        }
       
        yield return new WaitForSecondsRealtime(1f);
    }
}
