
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
            WeapondUI.text = "first"; 
        }
        else if (WeaponManager.Weapond2_Active)
        {
             WeapondUI.text = "second";    
        }
    }
}
