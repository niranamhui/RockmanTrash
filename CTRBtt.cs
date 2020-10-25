using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTRBtt : MonoBehaviour
{
    public GameObject Player;
    Movement crtPlayer;

    private void Start()
    {
        crtPlayer = Player.GetComponent<Movement>();
    }
    public void MoveLeft()
    {
        crtPlayer.LeftPressBtt();
    }
    public void MoveRigt()
    {
        crtPlayer.RigtPressBtt();
    }
    public void MoveJume()
    {
        crtPlayer.JumePressBtt();
    }
    public void StopMove()
    {
        crtPlayer.UpBtt();
    }
}
