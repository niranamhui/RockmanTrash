using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRocman : MonoBehaviour
{
    public GameObject shot;
    public Transform shotspot;
    public float firtrate;
    private float nextfirt;
    public float speedd;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && Time.time > nextfirt)
        {
            Shoot();

        }

    }

    void Shoot ()
    {
        nextfirt = Time.time + firtrate;
        Instantiate(shot, shotspot.position, shotspot.rotation);
    }
}
