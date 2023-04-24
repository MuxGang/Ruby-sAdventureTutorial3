using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private static Manager _instance;
    
    public static Manager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance = null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //============================================
    public static int level;
    public int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current scene index is " + currentSceneIndex);

        if (currentSceneIndex == 0)
        {
            level = 1;
            Debug.Log("scene 1");
        }
        if (currentSceneIndex == 1)
        {
            level = 2;
            Debug.Log("scene 2");
        }
        
    }

    void Update()
    {
        //Scene currentScene = SceneManager.GetActiveScene();
        

       /* if (currentSceneIndex==0)
        {
            level = 1;
            Debug.Log("scene 1");
        }
        if(currentSceneIndex==1)
        {
            level = 2;
            Debug.Log("scene 2");
        }*/
    }
}
