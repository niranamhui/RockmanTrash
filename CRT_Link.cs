using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CRT_Link : MonoBehaviour
{
    public void LoadScene(string nameScenes)
    {
        SceneManager.LoadScene(nameScenes);
    }
}
