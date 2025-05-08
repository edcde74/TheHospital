using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterBut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
            { GameObject.FindGameObjectWithTag("Safe").GetComponent<OpenDoor>().EnterDigit(); });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
