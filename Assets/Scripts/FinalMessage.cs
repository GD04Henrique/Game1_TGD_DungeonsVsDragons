using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalMessage : MonoBehaviour
{
    public Text _finalMessage;
    // Start is called before the first frame update
    void Start()
    {
        if(Timer._isClearGame == true)
        {
            _finalMessage.text = "CONGRATULATIONS YOU ARE A TRUE WARRIOR!!";
        }
        else
        {
            _finalMessage.text = "YOU FAILED TO CLEAR THE DUNGEON!";

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
