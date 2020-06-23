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
        int rand;
        int temp = 0;
        for (int i = 0; i < level; i++)
        {
            rand = Random.Range(0, 4);
            while (temp == rand)
            {
                rand = Random.Range(0, 4);
            }
            names[i] = buttons[rand].tag;
            temp = rand;
        }
        StartCoroutine(InitializeLights());
    }
    IEnumerator InitializeLights()
    {
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
        button.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        button.SetActive(false);
    }

    void CheckClicks()
    {

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