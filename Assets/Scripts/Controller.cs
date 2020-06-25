using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject redButtonOn;
    [SerializeField] private GameObject yellowButtonOn;
    [SerializeField] private GameObject greenButtonOn;
    [SerializeField] private GameObject blueButtonOn;
    [SerializeField] private string[] names = new string[10];
    [SerializeField] private GameObject GameOverPanel ;
    [SerializeField] private GameObject win ; 
    private int level = 3;
    private bool wonGame = false;
    private int percent = 0 ;

    int generateNumber()
    {
        return Random.Range(0 , 4);
    }

    public int percentage { 
        get { return percent ;}
    }

    void InitializeGame()
    {
        //initialize the sequence of lights in the game , the lengh of the sequence is the level number that the
        //user is on, the higher the level the longer the sequence 
        int rand;
        int temp = 0;
        for (int i = 0; i < level; i++)
        {
            rand = Random.Range(0, 4);
            while (temp == rand)
            {
                //make sure the lights do not repeat in sequence
                rand = Random.Range(0, 4);
            }
            names[i] = buttons[rand].tag;
            temp = rand;
        }
        StartCoroutine(InitializeLights());
    }
    IEnumerator InitializeLights()
    {
        //blink the lights based on the sequence generated with InitializeGame() with a small delay between 
        //each blink 
        yield return new WaitForSeconds(1);
        for (int i = 0; i < names.Length; i++)
        {
            switch (names[i])
            {
                case "RED":
                    StartCoroutine(LightsFlash(redButtonOn));
                    yield return new WaitForSeconds(0.1f);
                    break;
                case "BLUE":
                    StartCoroutine(LightsFlash(blueButtonOn));
                    yield return new WaitForSeconds(0.1f);
                    break;
                case "GREEN":
                    StartCoroutine(LightsFlash(greenButtonOn));
                    yield return new WaitForSeconds(0.1f);
                    break;
                case "YELLOW":
                    StartCoroutine(LightsFlash(yellowButtonOn));
                    yield return new WaitForSeconds(0.1f);
                    break;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    void Start()
    {
        InitializeGame();
    }
    int i = 0;

    private IEnumerator LightsFlash(GameObject button)
    {
        //switch between the buttonON and buttonOff images to mimick a light blinking
        button.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        button.SetActive(false);
    }

    void CheckClicks()
    {
        //check if the user clicked on the lights and if the light the user clicked on is not the right
        //one in sequence the game over panel will be displayed to inform the user that she/he has lost
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == names[i])
                {
                    switch (hit.collider.gameObject.tag)
                    {
                        case "RED":
                            StartCoroutine(LightsFlash(redButtonOn));
                            break;
                        case "BLUE":
                            StartCoroutine(LightsFlash(blueButtonOn));
                            break;
                        case "GREEN":
                            StartCoroutine(LightsFlash(greenButtonOn));
                            break;
                        case "YELLOW":
                            StartCoroutine(LightsFlash(yellowButtonOn));
                            break;
                    }
                    i++;

                    if (names[i] == "")
                    {
                        //the user would have won the game if the the next color in sequence is empty
                        wonGame = true;
                        i = 0;
                    }

                }
                else if (hit.collider.gameObject.tag != names[i])
                {
                    GameOverPanel.SetActive(true);
                }
            }
        }
    }

    void Update()
    {
        CheckClicks();
        if (wonGame == true)
        {
             if(level == names.Length) { 
                win.SetActive(true);
            }
            level++;
            percent += 10 ;
            
            InitializeGame();
            wonGame = false;
        }
    }
}