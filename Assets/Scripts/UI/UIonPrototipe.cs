
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UIScriptPrototipe : MonoBehaviour
{
    [Header("User Interface Path Specification")]

    [SerializeField] public TMP_Text HealthTextUI; 
    [SerializeField] public TMP_Text WeapondUI; 
    [SerializeField] public Image healthBarImage; 

    [Header("stats")]
    [SerializeField] GameWeaponTestFromCamara Weapon_1; 
    [SerializeField] GameManager Gmanagaer; 
    [SerializeField] WeaponManager WeaponManager; 
    [SerializeField] PlayerHPandStadistics Stadistics;
    
    //UIMessegeforWeaponds

    private string weponactiveUI; 

    void Update()
    {
        OverloadUIFunction(); 
        OverloadUIFunction_Weaponds();

    }

    void OverloadUIFunction()
    {
        HealthTextUI.text = "HP: " + Mathf.Ceil(Stadistics.PlayerHPStatus).ToString() + " | " + Stadistics.PlayerStats.MaxHP.ToString();  
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
}
