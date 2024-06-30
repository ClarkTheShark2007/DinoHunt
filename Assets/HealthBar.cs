using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerHealth playerHealth;
    List<HealthHeart> hearts = new List<HealthHeart>();

    private void OnEnable() 
    {
        PlayerHealth.OnPlayerDamaged += DrawHearts;
    }

    private void OnDisable() 
    {
        PlayerHealth.OnPlayerDamaged -= DrawHearts;
    }

    public void Start() 
    {
        Debug.Log("Start");
        DrawHearts();
    }

    public void DrawHearts() 
    {
        ClearHearts();
        
        float maxHealthRemainder = playerHealth.maxHealth % 2;
        int heartsToMake = (int)((playerHealth.maxHealth / 2) + maxHealthRemainder);
        for(int i = 0; i < heartsToMake; i++) 
        {
            CreateEmptyHeart();
        }

        for(int i = 0; i < hearts.Count; i++) 
        {
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.currentHealth - (i*2), 0, 2);
            hearts[i].SetHeartImage((HealthHeart.HeartStatus)heartStatusRemainder);
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HealthHeart.HeartStatus.Empty);
        hearts.Add(heartComponent);
    }
    public void ClearHearts() 
    {
        foreach(Transform t in transform) 
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }


}
