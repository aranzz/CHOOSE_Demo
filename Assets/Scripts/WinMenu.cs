using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{

    public static string nextScene;
    public static string currentScene;

    public static float current;

    float current2;

    public Text level;
    public Text level2;

    // Start is called before the first frame update
    void Start()
    {
        level.text = "" + current;
        current2 = current + 1;
        level2.text = "" + current2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void Next()
    {
        SceneManager.LoadScene(nextScene);
    }
}
