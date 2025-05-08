using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingProgress : MonoBehaviour
{
    [SerializeField] Image progressBar;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LodingScene.Instance.isLoading)
        {
            if(!(LodingScene.nextSceneIndex == 0))
            {             
                if (!(GameObject.FindGameObjectWithTag("Canvas") == null))
                {
                    Debug.Log("1");
                    for (int i = 0; i < GameObject.FindGameObjectWithTag("Canvas").transform.childCount; i++)
                    {

                        GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(i).gameObject.SetActive(false);
                    }
                    GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                }
                else
                {
                    
                }
                                            
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("Canvas"));
            }
            
            Time.timeScale = 1;
            StartCoroutine(LoadScene());
            LodingScene.Instance.isLoading = false;
        }
    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(LodingScene.nextSceneIndex);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
        
    }
}
