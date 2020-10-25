using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coin : MonoBehaviour
{
    public GameObject[] coinobj;
    public Color[] skillcolor;
    int coincolor = 4;
    //public int increaseCoin;
    //public Text Txtcoinn;

    private void Start()
    {
        int W = 0;
        {
            while (W < coincolor)//ลูปใส่สีให้กับObject
            {
                coinobj[W].GetComponent<Renderer>().material.color = Color.green;
                W++;
            }
        }
    }

    // private void Update()
    // {
    //int.Parse(GameObject.FindGameObjectWithTag("coinText").GetComponent<Text>().text);
    //   coin = int.Parse(GameObject.FindGameObjectWithTag("coinText").GetComponent<Text>().text);


    // }
    //private void OnCollisionEnter2D(Collision2D collision)
    //  {
    // if (collision.gameObject.tag == "Player")
    // {
    //  coin += increaseCoin;
    //     Txtcoinn.text = "Score  " + coin.ToString();
    //    Destroy(gameObject);

    //  }
    // }

}
