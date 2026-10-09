using UnityEngine; 
using RMC.SaveFile.SaveSerialice;
using VoidLine_LibaryOfStructures; 
using UnityEngine.UIElements;
using Unity.VisualScripting;

namespace RMC.SaveFile.Update_Data
{
    class data_ReferencesForUpdate : MonoBehaviour
    {
        [Header ("Player")]
        [SerializeField] public  static  PlayerHPandStadistics PlayerStats;
        [SerializeField] public static Transform PlayerPosition;
        
        [Header ("ExplosivePayload")] 
        [SerializeField] public static TheExplosivePackageScriptTest Epayload; 

    }

    public class update_Struct_ForSave 
    {
        public static void UpdatePlayer(Player_VoidLine_Stats.VoidLine_Statas Stats)
        {
            Stats.Max_HP = data_ReferencesForUpdate.PlayerStats.VoidLineStats.Max_HP; 
            Stats.HP_Status = data_ReferencesForUpdate.PlayerStats.VoidLineStats.HP_Status; 
            Stats.PlayerPosition = data_ReferencesForUpdate.PlayerPosition.position; 
            Stats.Informacion_Money = data_ReferencesForUpdate.PlayerStats.VoidLineStats.Informacion_Money; 
        }

    }
}