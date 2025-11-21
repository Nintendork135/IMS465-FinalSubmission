using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextboxInteract : MonoBehaviour
{

    public TMP_Text textbox;
    public List<string> myText = new List<string>();
    public bool canTalk = false;
    public bool isFriend;
    public GameObject Heart;
    [SerializeField] private Vector3 itemSpawn;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(myText.Count);
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canTalk && Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("Egg");

                if (textbox.gameObject.activeSelf == false)
                {
                    textbox.gameObject.SetActive(true);
                    //textbox.text = myText;
                }

                if (count <= myText.Count -1)
                {
                    textbox.text = myText[count];
                    count++;
                }
                else
                {
                    textbox.gameObject.SetActive(false);
                    count = 0;
                    if (isFriend)
                    {
                        Instantiate(Heart, itemSpawn, Quaternion.identity);
                        isFriend = false;

                    }
                }
                    

            }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canTalk = true;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canTalk = false;
            textbox.gameObject.SetActive(false);
            count = 0;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
