using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cosplay_Bot : MonoBehaviour 
{
    private HFSM fsm;

    void Start()
    {
        fsm = new HFSM(this.transform);
    }

    void Update()
    {
        fsm.Update();
    }
}
