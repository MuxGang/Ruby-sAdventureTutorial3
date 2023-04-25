using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BotFixCount : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public static bool winActive;
    public GameObject continueTextObject;
    public static bool continueActive;

    public static int fixCount;
    //public Manager manager;
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

        fixCount = 0;

        SetCountText();

        winTextObject.SetActive(false);
        winActive = false;
        continueTextObject.SetActive(false);
        continueActive = false;
    }
    void Update()
    {
        SetCountText();
    }
    public void SetCountText()
    {
        if (level == 1)
        {
            countText.text = "Bots Fixed: " + fixCount.ToString() + "/4";
        }
        if(level==2)
        {
            countText.text = "Bots Fixed: " + fixCount.ToString() + "/6";

        }
        if ((fixCount==4)&&(level==1))
        {
            continueTextObject.SetActive(true);
            continueActive = true;
        }
        if ((fixCount == 6)&&(level==2))
         {
            winTextObject.SetActive(true);
            winActive = true;
         }
      }    
     
    
    
}
