using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour, IPointerDownHandler
{
    public Ammo ammoCount;

    private SpawnerV2 enemyDeath;

    public int maxHealth = 3;
    public int currentHealth;
    

    void Start() 
    {
        currentHealth = maxHealth;
    }
    void Awake() 
    {
        ammoCount = FindObjectOfType<Ammo>();
        enemyDeath = FindObjectOfType<SpawnerV2>();
    }

    void Update() 
    {
        if (currentHealth == 0) 
        {
            SoundManger.PlaySound(SoundType.MINIDIE, 0.4f);
            enemyDeath.enemyKilled++;
            Destroy(gameObject);
            ScoreManger.Instance.AddPoint();
        }
    }

    public void OnPointerDown(PointerEventData eventData) 
    {

        if (eventData.button == PointerEventData.InputButton.Right) 
        {
            Debug.Log("DinoReload");
            ammoCount.DinoReload();
        }
        //if (ammoCount.ammo = 0)

        /*if (ammoCount.ammo > 0 && currentHealth == 0 && eventData.button == PointerEventData.InputButton.Left) 
        {
            SoundManger.PlaySound(SoundType.SHOT);
            ammoCount.ammo--;
            Destroy(gameObject);
            if (eventData.button == PointerEventData.InputButton.Left) print("Dino Dead");
            ScoreManger.Instance.AddPoint();
        }*/

        if (ammoCount.ammo > 0 && currentHealth > 0 && eventData.button == PointerEventData.InputButton.Left) 
        {
            SoundManger.PlaySound(SoundType.SHOT);
            ammoCount.ammo--;
            SoundManger.PlaySound(SoundType.ROAR, 0.7f);
            TakeDamage();
        }

        if (ammoCount.ammo == 0 && eventData.button == PointerEventData.InputButton.Left) 
        {
            SoundManger.PlaySound(SoundType.EMPTY);

        }

    }

        public void TakeDamage() 
        {
            currentHealth--;
        }
}
