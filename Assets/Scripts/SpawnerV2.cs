using System.Collections;
using UnityEngine;
using TMPro;

public class SpawnerV2 : MonoBehaviour
{

    
public static SpawnerV2 Instance;
public TextMeshProUGUI waveCountText;
    int waveCount = 0;

    private float spawnRate = 5.0f;
    //public float timeBetweenWaves = 400.0f;

    public int enemyCount = 1;
    public int enemyRequired = 1;
    public int bossRequired = 1;

    public int enemyKilled = 0;

    public int bossKilled = 0;

    [SerializeField]
    private GameObject redDinoPrefab;
    [SerializeField]
    private GameObject blueDinoPrefab;
    [SerializeField]
    private GameObject greenDinoPrefab;
    [SerializeField]
    private GameObject flyredDinoPrefab;
    [SerializeField]
    private GameObject flyblueDinoPrefab;

    [SerializeField]
    private GameObject flygreenDinoPrefab;
    public GameObject brontoBossPrefab;

    public GameObject themeMusic;
    public GameObject bossMusic;
    public GameObject resultMusic;
    public GameObject winUI;

    public GameObject upgradeUI;
    private PlayerHealth playerHealth;


    private float redDinoInterval = 8.5f;
    private float blueDinoInterval = 6.5f;
    private float greenDinoInterval = 14f;
    private float flyredDinoInterval = 10.5f;
    private float flyblueDinoInterval = 8.5f;
    private float flygreenDinoInterval = 15f;
    bool waveIsDone = true;
    void Start()
    {
        playerHealth  = GameObject.FindGameObjectWithTag("ScreenManger")?.GetComponent<PlayerHealth>(); 
    }

    void Update()
    {
        waveCountText.text = "" + waveCount.ToString();

        if (waveIsDone == true)
        {
            StartCoroutine(waveSpawner());
        }

        if(bossKilled == bossRequired) 
        {
            waveIsDone = true;
        }

        else if(enemyKilled == enemyRequired) 
        {
            waveIsDone = true;
            playerHealth.Heal(6);
        }
        
    }

    IEnumerator waveSpawner()
    {
        waveIsDone = false;

        for (int i = 0; i < enemyCount; i++)
        {

            if(bossKilled == 1) 
            {
                Debug.Log("You Win");
                bossRequired = 2;
                Destroy(bossMusic);
                Destroy(themeMusic);
                SoundManger.PlaySound(SoundType.VICTORY);
                StartCoroutine(Music());
                winUI.SetActive(true);
                Destroy(bossMusic);

            }

            if(enemyKilled == 0) 
            {
                waveCount += 1;
                enemyRequired = 2;
                StartCoroutine(spawnDino(redDinoInterval, redDinoPrefab));

            }

            if(enemyKilled == 2) 
            {   
                WaveUpgrade();
                waveCount += 1;
                enemyRequired = 6;
                StartCoroutine(spawnDino(blueDinoInterval, blueDinoPrefab));
                yield return new WaitForSeconds(spawnRate);
            }

            if(enemyKilled == 6) 
            {
                WaveUpgrade();
                waveCount += 1;
                enemyRequired = 12;
                StartCoroutine(spawnDino(greenDinoInterval, greenDinoPrefab));
                yield return new WaitForSeconds(spawnRate);
            }

            if(enemyKilled == 12) 
            {
                WaveUpgrade();
                waveCount += 1;
                enemyRequired = 24;
                StartCoroutine(spawnDino(flyredDinoInterval, flyredDinoPrefab));
                yield return new WaitForSeconds(spawnRate);
            }

            if(enemyKilled == 24) 
            {
                WaveUpgrade();
                waveCount += 1;
                enemyRequired = 36;
                StartCoroutine(spawnDino(flyblueDinoInterval, flyblueDinoPrefab));
                yield return new WaitForSeconds(spawnRate);
            }

            if(enemyKilled == 36) 
            {
                WaveUpgrade();
                waveCount += 1;
                enemyRequired = 48;
                StartCoroutine(spawnDino(flygreenDinoInterval, flygreenDinoPrefab));
                yield return new WaitForSeconds(spawnRate);
            }

            if(enemyKilled == 48) 
            {
                waveCount += 1;
                enemyRequired = 10000;
                StopAllCoroutines();
                StartCoroutine(hellBreaks());
                Destroy(themeMusic);
                bossMusic.SetActive(true);
                Instantiate(brontoBossPrefab);
                yield return new WaitForSeconds(spawnRate);
            }
        }

        //enemyCount += 1;
        //waveCount += 1;

       yield return new WaitForSeconds(5);

    }

    private IEnumerator spawnDino(float interval, GameObject dino) 
    {
        yield return new WaitForSeconds(interval);
        GameObject newDino = Instantiate(dino, new Vector3(Random.Range(-5f,5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnDino(interval, dino));
    }

    IEnumerator hellBreaks() 
    {
        yield return new WaitForSeconds(8);
        StartCoroutine(spawnDino(redDinoInterval, redDinoPrefab));
        StartCoroutine(spawnDino(blueDinoInterval, blueDinoPrefab));
        StartCoroutine(spawnDino(greenDinoInterval, greenDinoPrefab));
        StartCoroutine(spawnDino(flyredDinoInterval, flyredDinoPrefab));
        StartCoroutine(spawnDino(flyblueDinoInterval, flyblueDinoPrefab));
        StartCoroutine(spawnDino(flygreenDinoInterval, flygreenDinoPrefab));
        
    }

    public void WaveUpgrade() 
    {
        Time.timeScale = 0;
        upgradeUI.SetActive(true);
    }

    public void stopDinos() 
    {
        StopAllCoroutines();
    }

    private IEnumerator Music() 
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        resultMusic.SetActive(true);
        Debug.Log("Music");
    }
}
