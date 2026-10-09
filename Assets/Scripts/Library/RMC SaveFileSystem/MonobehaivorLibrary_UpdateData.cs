using UnityEngine; 
using RMC.SaveFile.SaveSerialice;
using RMC.SaveFile.SaveComposition;
using VoidLine_LibaryOfStructures; 
using UnityEngine.UIElements;
using Unity.VisualScripting;

namespace RMC.SaveFile.Update_Data
{
    class _Update_Data : MonoBehaviour
    {
        [Header ("Player")]
        [SerializeField] public  static PlayerHPandStadistics PlayerStats;
        [SerializeField] public static Transform PlayerPosition;
        [SerializeField] public static GameManager Gmanager; 
        
        [Header ("ExplosivePayload")] 
        [SerializeField] public static TheExplosivePackageScriptTest Epayload; 
        

    }

    public class UpdateData 
    {
        public static void UpdatePlayer(Player_VoidLine_Stats.VoidLine_Statas Stats, TheExplosivePackageScriptTest Epackage)
        {
            Stats.Max_HP = _Update_Data.PlayerStats.VoidLineStats.Max_HP; 
            Stats.HP_Status = _Update_Data.PlayerStats.VoidLineStats.HP_Status; 
            Stats.PlayerPosition = _Update_Data.PlayerPosition.position; 
            Stats.Informacion_Money = _Update_Data.PlayerStats.VoidLineStats.Informacion_Money;
            SaveFile_Data.GameData.enum_Race_Data = (int) GameManager.player_Race;
            Epackage.ExplosivePayload_Stadistics.In_InventoryPayload = _Update_Data.Epayload.ExplosivePayload_Stadistics.In_InventoryPayload;
        }

        //Continue whit payload
    }
}