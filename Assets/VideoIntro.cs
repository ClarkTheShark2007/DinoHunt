using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoIntro : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject realUi;
    void Start()
    {
        StartCoroutine(Dissapear());
    }

    IEnumerator Dissapear() 
    {
        yield return new WaitForSeconds(10);
        GameObject.Destroy(gameObject);
        realUi.SetActive(true);

    }
}
