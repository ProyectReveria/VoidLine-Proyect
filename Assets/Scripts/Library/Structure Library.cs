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
    }
}