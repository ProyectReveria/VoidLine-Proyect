#if obsolete
using System;
using Unity.VisualScripting;
using UnityEngine;

public class WallCrashDamage : MonoBehaviour
{
    [SerializeField] private bool ColideOnPlayer; 
    [SerializeField] PlayerControl Pcontrol; 
    [SerializeField] PlayerHPandStadistics Pstadistics; 

    private void OnCollisionEnter (Collision Floor)
    {
        if (Floor.gameObject.CompareTag("Player"))
        {
            ColideOnPlayer = true; 
            if (Pcontrol.Increased_RunSpeed == Pcontrol.Base_MovementSpeed )
            {
                Pstadistics.PlayerHPStatus -= 0; 
            }
            else if (Pcontrol.Increased_RunSpeed > 10 && Pcontrol.Increased_RunSpeed < 20)
            {
            Pstadistics.PlayerHPStatus -= 10; 
            
            } else if (Pcontrol.Increased_RunSpeed > 20)
            {
                Pstadistics.PlayerHPStatus -= 20; 
            } 


        
        }
        
    }

    private void OnCollisionExit(Collision Floor)
    {
        if (Floor.gameObject.CompareTag("Player"))
        {
            ColideOnPlayer = false; 
        }
    }

    void Update()
    {

    }

}
#endif  