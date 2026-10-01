using UnityEngine;
using VoidLine_LibaryOfStructures; 


public class VoidLine_EnemyType : MonoBehaviour
{
    [Header ("EnemyStadistics")]  
    [SerializeField] public EnemyStructures.EnemyData NewEnemyData;

    [Header("EnemyObject")]
    [SerializeField] private GameObject Enemy; 

    

    void Update()
    {
        if (NewEnemyData.EnemyHP == 0)
        {
            Destroy(Enemy); 
        }
    }


}
