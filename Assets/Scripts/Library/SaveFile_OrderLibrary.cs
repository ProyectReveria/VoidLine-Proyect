using System.Collections.Generic;
using RMC.SaveFile.SaveSerialice;
using UnityEngine;
using UnityEngine.Events;

namespace RMC.SaveFile.SaveComposition
{

    class SaveFile
    {
        

        public List<dynamic> GameDAta = new List<dynamic>();

        class Update_PlayerData
        {
            
        }

        [System.Serializable] 
        class GameData
        {
            VoidLine_LibaryOfStructures.Player_VoidLine_Stats Stats; 
            VoidLine_LibaryOfStructures.EquipablesTools.Explosive_Payload Epayload; 
        }


    }
}

