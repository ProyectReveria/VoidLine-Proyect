
using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using VoidLine_LibaryOfStructures;

public class UIScriptPrototipe : MonoBehaviour
{
    [Header("User Interface Path Specification")]

    [SerializeField] public TMP_Text HealthTextUI; 
    [SerializeField] public TMP_Text WeapondUI; 
    [SerializeField] public TMP_Text YouLose_TMP;
    [SerializeField] public TMP_Text PayloadCounter; 
    [SerializeField] public Image healthBarImage; 

    [Header ("PlayerMesseges")]
    [SerializeField] private String Player_Die; 

    [Header("stats")]
    [SerializeField] GameWeaponTestFromCamara Weapon_1; 
    [SerializeField] GameManager Gmanagaer; 
    [SerializeField] WeaponManager WeaponManager; 
    [SerializeField] PlayerHPandStadistics Stadistics;
    [SerializeField] TheExplosivePackageScriptTest ExplosivePayloadStadistics; 
    
    //UIMessegeforWeaponds

    private string weponactiveUI; 

    void Update()
    {
        OverloadUIFunction(); 
        OverloadUIFunction_Weaponds();
        OverloadUIFunction_PlayerisDead(); 
        OverloadUIFunctrion_ExplosivePayload(); 

    }

    void OverloadUIFunction()
    {
        HealthTextUI.text = "HP: " + Mathf.Ceil(Stadistics.PlayerHPStatus).ToString() + " | " + Stadistics.VoidLineStats.Max_HP.ToString();  
    }

    void OverloadUIFunction_Weaponds()
    { 
        if (WeaponManager.weapon1_Active)
        {
           if (Weapon_1.isreloding == false)
            {
                 WeapondUI.text = $"Weapond municion: {Weapon_1.Mag}| {Weapon_1.Weapon_Stats.magazing}"; 
            }else if (Weapon_1.isreloding == true)
            {
                 WeapondUI.text = $"reloading"; 
            }
        }
        else if (WeaponManager.Weapond2_Active)
        {
             WeapondUI.text = "second";    
        }
    }

    void OverloadUIFunction_PlayerisDead()
    {
        if (Stadistics.playerisDead)
        {
            YouLose_TMP.text = Player_Die; 
        } else {
            YouLose_TMP.text = " "; 
        }
    }

    void OverloadUIFunctrion_ExplosivePayload()
    {
        PayloadCounter.text = $"Payloads: {ExplosivePayloadStadistics.ActualAmountofPayloads} | {ExplosivePayloadStadistics.ExplosivePayload_Stadistics.Payload_Inventory} "; 
    }

}
