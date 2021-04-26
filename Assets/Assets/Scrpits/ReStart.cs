using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Invoke("restart", 1.5f);
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Invoke("Exit", 0.1f);
        }
        if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene(4);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(3);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    
}
