using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Ammo : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{

    bool leftPointerDown = false;
    bool rightPointerDown = false;
    public int ammo = 3;
    public int maxAmmo = 3;
    public int reloadAmount = 1;
    float cooldownTime = 0f;
    public bool isFiring;
    public bool isReloading;
    public TextMeshProUGUI ammoDisplay;
   
    void Start() 
    {
    }

    void Update() 
    {
        ammoDisplay.text = ammo.ToString();
        if (cooldownTime > 0f)
        {
            cooldownTime -= Time.deltaTime;
        }

        if (ammo > maxAmmo) 
        {
            ammo = maxAmmo;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) 
        {
            leftPointerDown = true;
            Shoot();
            Debug.Log("Shot");
        }

        if (eventData.button == PointerEventData.InputButton.Right) 
        {
            rightPointerDown = true;
            Reload();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        leftPointerDown = false;
        rightPointerDown = false;
    }

    public void Shoot()
    {
        ammoDisplay.text = ammo.ToString();
        if (leftPointerDown && !isFiring && ammo > 0)
        {
            isFiring = true;
            SoundManger.PlaySound(SoundType.SHOT);
            ammo--;
            isFiring = false;
        }

        if (leftPointerDown && ammo == 0)
        {
            SoundManger.PlaySound(SoundType.EMPTY, 1);
        }
    }

    public void Reload()
    {
        ammoDisplay.text = ammo.ToString();
        if (rightPointerDown && !isReloading && ammo < maxAmmo && cooldownTime <= 0)
        {
            isReloading = true;
            SoundManger.PlaySound(SoundType.RELOAD);
            ammo += reloadAmount;
            isReloading = false;
            Debug.Log("Realoded");
            cooldownTime = 1f;
        }
    }

    public void DinoReload()
    {
        ammoDisplay.text = ammo.ToString();
        if (!isReloading && ammo < maxAmmo && cooldownTime <= 0)
        {
            isReloading = true;
            SoundManger.PlaySound(SoundType.RELOAD);
            ammo += reloadAmount;
            isReloading = false;
            Debug.Log("Realoded");
            cooldownTime = 1f;
        }
    }

    public void EnemyShot() 
    {
        ammo--;
        ammoDisplay.text = ammo.ToString();
    }

}
