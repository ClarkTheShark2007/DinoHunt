using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject realUi;
    public void Start() 
    {
        StartCoroutine(WaitForUi());
        
    }

    public void GrassLvl() 
    {
        SceneManager.LoadScene("GrassField");
    }

    public void WaterLvl() 
    {
        SceneManager.LoadScene("Underwater");
    }

    public void Menu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit() 
    {
        Debug.Log("GameQuit");
        Application.Quit();
    }

    IEnumerator WaitForUi() 
    {
        yield return new WaitForSeconds(10);
        realUi.SetActive(true);
        
    }
}
