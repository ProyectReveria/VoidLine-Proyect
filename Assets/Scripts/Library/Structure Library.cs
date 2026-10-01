using UnityEngine;

namespace VoidLine_LibaryOfStructures
{
    public class EnemyStructures
    {
        [System.Serializable]
        public struct EnemyData
        {
            public int EnemyHP; 
            public int EnemyDamage; 

            public bool Is_Active_Enemy; 
        }
    }
}