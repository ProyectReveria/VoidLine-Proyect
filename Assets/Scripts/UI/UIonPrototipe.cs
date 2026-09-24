
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UIScriptPrototipe : MonoBehaviour
{
    [Header("User Interface Path Specification")]

    [SerializeField] public TMP_Text HealthTextUI; 
    [SerializeField] public Image healthBarImage; 

    [Header("stats")]

    [SerializeField] PlayerHPandStadistics Stadistics;

    void Update()
    {
        OverloadUIFunction(); 
    }

    void OverloadUIFunction()
    {
        HealthTextUI.text = "HP: " + Mathf.Ceil(Stadistics.PlayerHPStatus).ToString() + " | " + Stadistics.PlayerStats.MaxHP.ToString();  
    }
}
