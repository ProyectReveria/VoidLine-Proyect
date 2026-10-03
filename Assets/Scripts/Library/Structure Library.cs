using UnityEngine;

namespace VoidLine_LibaryOfStructures
{
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
        }
        [System.Serializable]
        public struct Weapond_Stats
        {
            public int magazing;
            public int damaga;
            public float reloadTime; 
        }
    }

    
}