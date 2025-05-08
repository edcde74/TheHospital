using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClearBut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
            { GameObject.FindGameObjectWithTag("Safe").GetComponent<OpenDoor>().ClearDigit(); });
        }
    }
}
