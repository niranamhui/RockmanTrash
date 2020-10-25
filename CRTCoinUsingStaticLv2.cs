using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CRTCoinUsingStaticLv2 : MonoBehaviour
{
    public int increaseCoin;
    public Text coinTxet;
    public Text TxteWin;
    public Text ScoreTxet;
    int coin;
    public GameObject END;
    // Start is called before the first frame update

    private void Start()
    {
        END.SetActive(false);
    }
    private void Update()
    {
        coin = int.Parse(GameObject.FindGameObjectWithTag("coinText").GetComponent<Text>().text);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CoinData.coin += increaseCoin;
            CoinData.Score += increaseCoin;
            coinTxet.text = "Coin " + CoinData.coin.ToString();
            ScoreTxet.text = "Score " + CoinData.Score.ToString();
            Destroy(gameObject);

        }
        if (CoinData.coin >= 30)
        {
            increaseCoinTexe();
        }
    }
    public void increaseCoinTexe()
    {
        TxteWin.text = "Win";
        END.SetActive(true);
        Destroy(coinTxet);
    }
}
