using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWIn : MonoBehaviour
{

    public GameObject endScreen;
    public bool canRestart = false;
    private UIManager UI;
    private GameManager GM;
    public GameObject Music;
    public GameObject Score;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (canRestart == true && Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("LevelSelect");
            }
        
        
         
    }

    private void OnTriggerEnter2D(Collider2D collision)
   {
      if(collision.gameObject.tag == "Player")
      {
        Debug.Log("WIN");
        endScreen.SetActive(true);
        Music.SetActive(false);
        Score.SetActive(false);
       Destroy(collision.gameObject);
       canRestart = true;

      }
       
   }
}
