using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManger : MonoBehaviour
{

    public static ScoreManger Instance;
    [SerializeField] public TextMeshProUGUI scoreText;
    int Score;

    // Start is called before the first frame update

    private void Awake() 
    {
        Instance = this;
    }
    void Start()
    {
        scoreText.text = Score.ToString() + "";
    }

    // Update is called once per frame
    public void AddPoint()
    {
        Score += 1;
        scoreText.text = Score.ToString() + "";

    }
}
