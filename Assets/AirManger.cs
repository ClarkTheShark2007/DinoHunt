using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirManger : MonoBehaviour
{
    public Image airBar;
    public float airAmount = 100f;
    private PlayerHealth playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OverTimeAir());
        playerHealth  = GameObject.FindGameObjectWithTag("ScreenManger")?.GetComponent<PlayerHealth>(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoseAir(float loss) 
    {
        airAmount -= loss;
        airBar.fillAmount = airAmount / 100f;

        if (airAmount == 0) 
        {
            playerHealth.TakeDamage(100);
        }
    }

    public void GainAir(float gain) 
    {
        airAmount += gain;
        airAmount = Mathf.Clamp(airAmount, 0, 100);

        airBar.fillAmount = airAmount / 100f;

    }

    IEnumerator OverTimeAir() 
    {
        yield return new WaitForSeconds(2);
        airBar.fillAmount = airAmount / 100f;
        LoseAir(5);
        StartCoroutine(OverTimeAir());
    }
}
