using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSpanwer : MonoBehaviour
{
    [SerializeField]
    private GameObject rbubbleDinoPrefab;
    [SerializeField]
    private GameObject bbubbleDinoPrefab;

    private float rbubbleDinoInterval = 3.5f;
    private float bbubbleDinoInterval = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnDino(rbubbleDinoInterval, rbubbleDinoPrefab));
        StartCoroutine(spawnDino(bbubbleDinoInterval, bbubbleDinoPrefab));
    }

    // Update is called once per frame
    private IEnumerator spawnDino(float interval, GameObject dino) 
    {
        yield return new WaitForSeconds(interval);
        GameObject newDino = Instantiate(dino, new Vector3(Random.Range(-5f,5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnDino(interval, dino));
    }
}
