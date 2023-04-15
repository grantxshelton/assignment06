using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    public static ReadInput readInput;
    public InputField playerInput;
    public Text playerText;
    public static string playerName;

    public void Start()
    {
        if(playerName != null)
        {
            playerText.text = playerName.ToUpper(); //Saves playername between scenes
        }
    }
    public void ReadStringInput()
    {
        playerName = playerInput.text.ToString(); //Sets string 'playerName' to input field text
        playerText.text = playerName.ToUpper(); //Sets text on screen to playerName & uppercases it
    }
}
