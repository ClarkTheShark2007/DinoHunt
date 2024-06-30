using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    public Ammo ammoCount;
    private PlayerHealth playerHealth;

    void Start() 
    {
        playerHealth  = GameObject.FindGameObjectWithTag("ScreenManger")?.GetComponent<PlayerHealth>();
    }

    public void GrassLvl() 
    {
        SceneManager.LoadScene("GrassField");
        Time.timeScale = 1;
    }

    public void WaterLvl() 
    {
        SceneManager.LoadScene("Underwater");
        Time.timeScale = 1;
    }

    public void Menu() 
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Exit() 
    {
        Debug.Log("GameQuit");
        Application.Quit();
    }

    public void ammoUpgrade() 
    {
        ammoCount.maxAmmo += 1;
        Time.timeScale = 1;
    }

    public void reloadUpgrade() 
    {
        ammoCount.reloadAmount += 1;
        Time.timeScale = 1;
    }

    public void missUpgrade() 
    {
        playerHealth.Increase(2);
        playerHealth.Heal(2);
        Time.timeScale = 1;
    }
}
