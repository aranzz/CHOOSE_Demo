using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour
{

    public string nextScene;
    public string scene;

    string win = "WinScreen";
    string fail = "FailScreen";

    public float current;

    public GameObject arrows;

    // Start is called before the first frame update
    void Start()
    {
        arrows.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Score());
        StartCoroutine(ArrowsMove()); 
    }

    public void Restart()
    {
        SceneManager.LoadScene(scene);
    }

    //Método para borrar las felchas, Tap y Warnings de la pantalla después de 3 segundos
    IEnumerator ArrowsMove()
    {
        yield return new WaitForSeconds(3);
        arrows.SetActive(false);
      
    }
    IEnumerator Score()
    {
        //Cargará la escena correspondiente después de 3 segundos
        if(BunnyController.fail == true)
        {
            WinMenu.nextScene = nextScene;
            WinMenu.currentScene = scene;
            WinMenu.current = current;
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(fail);
        }
     
        if(BunnyController.success == true)
        {
            WinMenu.nextScene = nextScene;
            WinMenu.currentScene = scene;
            WinMenu.current = current;
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(win);

        }
    }

   

}
