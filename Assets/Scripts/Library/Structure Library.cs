using System;
using UnityEngine;

namespace VoidLine_LibaryOfStructures
{
    
    public class Player_VoidLine_Stats
    {
        [System.Serializable]
        public struct VoidLine_Statas
        {
            public Int64 Max_HP; 
            public float DeadTime; 
        }
    }
    public   class EnemyStructures
    {
        [System.Serializable]
        public  struct EnemyData
        {
            public  int EnemyHP; 
            public  int EnemyDamage; 
            public  bool Is_Active_Enemy; 
            public float AttackRange; 
        }


    }
    
    public class EquipablesTools
    {
        [System.Serializable]
        public  struct Explosive_Payload
        {
            public  float explosivepayload_Range; 
            public  int explosivepayload_Damage;
            public  int explosivepayload_Damge_ToPlayer; 
            public  float Explosive_Payload_Force; 
            public float TimeBetweenPayload; 
            public int Payload_Inventory;
            public float ExploiveInput_Payload; 
        }
        [System.Serializable]
        public struct Weapond_Stats
        {
            public int magazing;
            public int damaga;
            public float reloadTime; 
        }
    }

    public struct Enviorment_Objects_Loot
    {
        [System.Serializable]
        public struct @Service_LootBox
        {
            [Header ("Items Probability")]
            public float _LifePackage_Prob; 
            public float _Payload_Prob; 
            public float  _MunicionPayload; 
            public float _None; 

            [Header ("Quantity")]
            public int _LifePackage_HealingByPackage; 
            public int _Payload_AddtoInventoryAmount; 
            public int _Municion_AddToInventory; 
            [Header ("Item_Visuals")]

            public GameObject LifePackage; 
            public GameObject ExplosivePayload; 
            public GameObject _MunicionPayLoad; 

            [Header ("DropZone and Box")]
            public Vector3 _LootPosition_AfterBox_Delete; 
            public GameObject box;  
        }
    }
    
}