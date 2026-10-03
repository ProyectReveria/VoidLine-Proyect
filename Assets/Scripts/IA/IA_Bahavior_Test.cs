using UnityEngine;
using UnityEngine.AI; 
public class IA_Bahavior_Test : MonoBehaviour
{
    //playerData
    [Header ("Player")]
    [SerializeField] Transform player_Transform; 

    [Header ("Enemy")]
    [SerializeField] GameObject enemy; 
    [SerializeField] VoidLine_EnemyType enemydata; 
    
    //Dynamic variables
    private float M_Distance; 
    private NavMeshAgent Enemy_NAvMesh; 

    void Start()
    {
        Enemy_NAvMesh = enemy.GetComponent<NavMeshAgent>(); 
    }

    void Update()
    {
        M_Distance = Vector3.Distance(enemy.transform.position, player_Transform.position); 

        if (M_Distance < enemydata.NewEnemyData.AttackRange)
        {
            Enemy_NAvMesh.isStopped = true;
        }
        else
        {
            Enemy_NAvMesh.isStopped = false; 
            Enemy_NAvMesh.destination = player_Transform.position; 
        }
    }


}
