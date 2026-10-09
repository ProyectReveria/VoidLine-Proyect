using System.Collections.Generic;
using RMC.SaveFile.SaveSerialice;
using UnityEngine;
using UnityEngine.Events;

namespace RMC.SaveFile.SaveComposition
{

    public class SaveFile_Data
    {

        [System.Serializable] 
        public static class GameData
        {
            static VoidLine_LibaryOfStructures.Player_VoidLine_Stats Stats; 
            static VoidLine_LibaryOfStructures.EquipablesTools.Explosive_Payload Epayload; 

            public static int enum_Race_Data; 
        }


    }
}

