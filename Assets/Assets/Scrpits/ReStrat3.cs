using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStrat3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Invoke("restart", 1.5f);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Invoke("Exit", 0.1f);
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(4);
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
