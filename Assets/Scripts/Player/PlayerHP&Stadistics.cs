using System;
using UnityEngine;

    //Player Stadistics ITSELF
public class PlayerHPandStadistics : MonoBehaviour
{
        [Header("Referencial Data")]
        [SerializeField] public Voidline_Stats PlayerStats; 
        [SerializeField] public bool Ishuman; 
        [SerializeField] public bool IsDemon; 
        [SerializeField] public Int64 PlayerHPStatus; 


        //Scripts & objects
        [SerializeField] private PlayerControl PlayerControl;  

        [SerializeField] private GameManager GameManager;
        


//Update & Awake
    void Awake()
    {
        switch (GameManager.player_Race)
        {
            case GameManager.Race.Angel:
                PlayerControl.RLigthLimit *= 1.20f; 
                break;
            case GameManager.Race.Demon:
                IsDemon = true; 
                break;
            case GameManager.Race.Human:
            Ishuman = true; 
            break; 
        }

        PlayerHPStatus = PlayerStats.MaxHP; 
        
    }

}

[System.Serializable]
public class Voidline_Stats
{
    public GameManager.Race Race; 
    public Int64 MaxHP; 
    public int Defence; 

}
    //GameControlReference

    


