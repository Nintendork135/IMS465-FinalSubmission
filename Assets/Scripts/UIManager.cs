using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite[] lifeImages;
    [SerializeField] private Image lifeDisplay;
    [SerializeField] private GameObject splashScreen; //GameObject for SetActive()
    private GameManager GM;
    private BrambleMovement B;
    public Text scoreDisplay;
    [SerializeField] private Image keyStatus;
    [SerializeField] private Sprite noKey;
    [SerializeField] private Sprite yesKey;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (B == null)
            B = GameObject.FindWithTag("Player").GetComponent<BrambleMovement>();

        if(B.hasKey)
        {
            keyStatus.sprite = yesKey;
        } else
        {
            keyStatus.sprite = noKey;
        }
    }

    public void UpdateScore()
    {
        scoreDisplay.text = "Score : " + B.ScoreCount; //concatenation, glue together
    }

    public void UpdateLives(int currentLives) //formal parameter
    {
        lifeDisplay.sprite = lifeImages[currentLives];
    }

    public void UpdateKey()
    {
        
    }
    public void ShowTitleScreen()
    {
        splashScreen.SetActive(true); //turn it on
        GM.gameOver = true;
    }

    public void HideTitleScreen()
    {
        splashScreen.SetActive(false); //turn it off

    }
}
