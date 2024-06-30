using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{

    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public SpawnerV2 daSpawner;

    public int maxHealth;
    public int currentHealth;
    public GameObject deathUi;

    public GameObject themeMusic;
    public GameObject bossMusic;
    public GameObject resultMusic;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        OnPlayerDamaged?.Invoke();
    }

    public void TakeDamage(int damage)  
    {
        currentHealth -= damage;
        OnPlayerDamaged?.Invoke();

        if (currentHealth <= 0) 
        {
            daSpawner.stopDinos();
            deathUi.SetActive(true);
            Destroy(bossMusic);
            Destroy(themeMusic);
            StartCoroutine(Music());
            SoundManger.PlaySound(SoundType.FAIL);
        }
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        OnPlayerDamaged?.Invoke();
        if(currentHealth>maxHealth){
            currentHealth=maxHealth;
        }
    }

    public void Increase(int heal)
    {
        maxHealth += heal;
        OnPlayerDamaged?.Invoke();
        if(currentHealth>maxHealth){
            currentHealth=maxHealth;
        }
    }

    private IEnumerator Music() 
    {
        Time.timeScale = 0;
        yield return new  WaitForSecondsRealtime(3);
        resultMusic.SetActive(true);
        Debug.Log("Music");
    }
}
