using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class LevelManangerr : MonoBehaviour
{
    [SerializeField] private Text text ; 
    [SerializeField] private Controller controller ;
    
    void Awake() {
    }

    void Update()
    {
        text.text = controller.percentage + "%";
    }
}
