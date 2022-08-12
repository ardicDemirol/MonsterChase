using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{

    void Start()
    {
       
    }

    void OnEnable()
    {
        //Sender.playerDiedInfo += PlayerDiedListener;
    }
    void OnDisable()
    {
        //Sender.playerDiedInfo -= PlayerDiedListener;
    }

    void PlayerDiedListener()
    {
        print("Event has called this function to execute");
    }

    


}
