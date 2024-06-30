using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkBossPattern : MonoBehaviour
{
    private Animator anim;
    private PlayerHealth playerHealth;
    void Awake () 
    {
        StartCoroutine(Timer());
    }
    IEnumerator Start()
    {

        playerHealth  = GameObject.FindGameObjectWithTag("ScreenManger")?.GetComponent<PlayerHealth>(); 
        anim = GetComponent<Animator>();

        while (true) 
        {

            anim.SetInteger("AttackIndex", Random.Range(0, 2));
            anim.SetTrigger("Attack");
        }
        
    }

    IEnumerator Timer() 
    {
        yield return new WaitForSeconds(70);
        playerHealth.TakeDamage(100);
        Destroy(gameObject);
    }
}
