using System.Collections;
using NUnit.Framework;
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

    [Header ("Player Stadistics")]
    [SerializeField] PlayerHPandStadistics PlayerStats; 
    
    //Dynamic variables
    private float M_Distance; 
    private NavMeshAgent Enemy_NAvMesh;
    private bool IframesActivte = false;
    private bool IsCollide = false; 


    void OnCollisionEnter(Collision HIT)
    {
        IsCollide = true; 
    }

    void OnCollisionExit(Collision collision)
    {
        IsCollide = false; 
    }

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
            if (IframesActivte == false && IsCollide)
            {
                PlayerStats.PlayerHPStatus -= enemydata.NewEnemyData.EnemyDamage; 
                StartCoroutine(ImunityframesMomentum()); 
            }

                

        }
        else
        {
            Enemy_NAvMesh.isStopped = false; 
            Enemy_NAvMesh.destination = player_Transform.position; 
        }
    }

    private IEnumerator ImunityframesMomentum()
    {
        
        IframesActivte = true; 

        yield return new WaitForSeconds(PlayerStats.Iframes);

        IframesActivte = false; 

    }

}
