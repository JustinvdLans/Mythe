using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandeler : MonoBehaviour
{
    [SerializeField]
    public enum States
        {ROAMINGSTATE,
         FOLLOWINGSTATE,
         ATTACKSTATE,
         SINKINGSTATE    
        };
    public States currentState;

    private void Start()
    {
        //currentState = States.ROAMINGSTATE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CurrentState()
    {
        
    }

    private void SwitchState()
    { 
    
    }
}
