using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrtText : MonoBehaviour
{
    public int amountIncrease;
    int coint;
    public Text TxtScore;
    public Text TxteWin;
    public Text TxteScoreSave;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coint += amountIncrease;
            TxtScore.text = "Coin " + coint.ToString();
            TxteScoreSave.text = "Score " + coint.ToString();
        }
        if (coint >= 3)
        {
            increaseCoin();
        }
    }
    public void increaseCoin()
    {
        TxteWin.text = "Win";
    }
}
