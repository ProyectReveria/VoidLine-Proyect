using System;
using System.Collections;
using VoidLine_LibaryOfStructures; 
using UnityEngine;

    //Player Stadistics ITSELF
public class PlayerHPandStadistics : MonoBehaviour
{
        [Header ("PlayerGameObject & SpawnPoint")]

        [SerializeField] public GameObject playergameobject; 
        [SerializeField] public Vector3 Origin; 

        [Header("Referencial Data")]
        [SerializeField] public bool Ishuman; 
        [SerializeField] public bool IsDemon; 

        [SerializeField] public float Iframes; 
        [SerializeField] public bool playerisDead; 

        [Header ("playerStats")]
        [SerializeField] public GameManager.Race Race; 
        [SerializeField] public Player_VoidLine_Stats.VoidLine_Statas VoidLineStats; 

        //Scripts & objects 
        [Header ("Managers & Controls")]
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
                PlayerControl.RLigthLimit *= 0.95f; 
                IsDemon = true; 
                break;
            case GameManager.Race.Human:
            Ishuman = true; 
            break; 
        }

        VoidLineStats.HP_Status = VoidLineStats.Max_HP; 
        
    }

    void Update()
    {
        if (VoidLineStats.HP_Status <= 0)
        {
            StartCoroutine(PlayerIsDead_Scene());
            playergameobject.transform.position = Origin; 
            playerisDead = true; 
            
            
        } else
        {
            playerisDead = false; 
        }
    }
    private IEnumerator PlayerIsDead_Scene()
    {
        PlayerControl.IsCamAndContBlock = true;

        yield return new WaitForSeconds(VoidLineStats.DeadTime); 
        VoidLineStats.HP_Status = VoidLineStats.Max_HP; 


        playerisDead = false; 
        PlayerControl.IsCamAndContBlock = false;
    }

}