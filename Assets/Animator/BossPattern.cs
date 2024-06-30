using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    private Animator anim;
    private PlayerHealth playerHealth;

    IEnumerator Start()
    {

        playerHealth  = GameObject.FindGameObjectWithTag("ScreenManger")?.GetComponent<PlayerHealth>(); 
        anim = GetComponent<Animator>();

        while (true) 
        {

            anim.SetInteger("AttackIndex", Random.Range(0, 2));
            anim.SetTrigger("Attack");

            yield return new WaitForSeconds(70);
            playerHealth.TakeDamage(100);
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
