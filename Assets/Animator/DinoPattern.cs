using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPattern : MonoBehaviour
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

            yield return new WaitForSeconds(9);
            playerHealth.TakeDamage(2);
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
