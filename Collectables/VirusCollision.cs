using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class VirusCollision : MonoBehaviour
{
    static Text Infection;
    private void Start()
    {
        Infection = GameObject.Find("Score").GetComponentInChildren<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UpdateInfection();
            Destroy(this.gameObject);

        }
       


    }
    private void UpdateInfection()
    {
        int startIndex = 0;//Start index of the number
        int num = 0;//the number in the string
        
        startIndex = Infection.text.LastIndexOf(':') + 1;
        string txt = Infection.text.Substring(startIndex, Infection.text.Length - startIndex - 1);
        num = Int32.Parse(txt); //Converting the digits in the text to integer
        
       
        
        num += 10;// add 10% of infection
        Infection.text = String.Format("Infection:{0}%", num.ToString()); //change the text
    }
}
