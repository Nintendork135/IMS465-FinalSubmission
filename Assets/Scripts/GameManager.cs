using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerTwo;
    private UIManager UI;
    private SpawnManager SM;

    public bool gameOver = true;

    public Vector3[] keyPlace;

    [SerializeField] private GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
        SM = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameOver)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Instantiate(player, new Vector3(-22.29f, -17.0f, 0f), Quaternion.identity); //player
                SpawnKey();
            }

            else
            {
                Instantiate(playerTwo, new Vector3(167.4553f, -17.04201f, 0f), Quaternion.identity); //player
                //change the position is very simple, change the else to change level 2 spawn
                SpawnKey();
            }

            gameOver = false;

            if (UI != null)
                UI.HideTitleScreen();
        }
    }
    
    void SpawnKey()
    {
        if (keyPlace.Length != 0) 
        {
            int keyCoords = Random.Range(0, keyPlace.Length);
            Instantiate(key, keyPlace[keyCoords], Quaternion.identity);
        }
    }

}
