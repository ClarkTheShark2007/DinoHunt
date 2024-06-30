using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject redDinoPrefab;

    private float redDinoInterval = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnDino(redDinoInterval, redDinoPrefab));
    }

    // Update is called once per frame
    private IEnumerator spawnDino(float interval, GameObject dino) 
    {
        yield return new WaitForSeconds(interval);
        GameObject newDino = Instantiate(dino, new Vector3(Random.Range(-5f,5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnDino(interval, dino));
    }
}
