using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{
    private int amountOfCoins = 0;
    [SerializeField] Text MyCoinsText;
    



    public void MoreCoins()
    {
        amountOfCoins++;


        MyCoinsText.text = amountOfCoins.ToString();

    }
  
}
