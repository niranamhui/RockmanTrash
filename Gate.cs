using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject player;
    public GameObject targetin;
    public GameObject targetout;

    void Start()
    {

    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);

        if (dist < 1.5f)
        {
            if (Input.GetKeyDown("i"))
            {
                player.transform.position = targetin.transform.position + Vector3.up * 0.43f;
            }

            if (Input.GetKeyDown("o"))
            {
                player.transform.position = targetout.transform.position + Vector3.up * 0.43f;
            }
        }
    }

}
