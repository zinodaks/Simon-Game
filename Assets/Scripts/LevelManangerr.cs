using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class LevelManangerr : MonoBehaviour
{
    //A simple scipt to display the percentage of the game complete
    [SerializeField] private Text text ; 
    [SerializeField] private Controller controller ;
    
    void Awake() {
    }

    void Update()
    {
        text.text = controller.percentage + "%";
    }
}
