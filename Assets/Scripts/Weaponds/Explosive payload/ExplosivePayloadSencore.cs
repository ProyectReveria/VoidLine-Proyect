using UnityEngine;
using VoidLine_Tags; 
using VoidLine_Tags; 

public class ExplosivePayloadSencore : MonoBehaviour
{

    [Header ("ExplosivePayloadScript")]
    [SerializeField] private PlayerHPandStadistics Player_Stats; 
    [SerializeField] private TheExplosivePackageScriptTest Payload;
    [SerializeField] private GameObject player; 
    

    void OnTriggerEnter(Collider other)
    {
        Collider[] array_Collider = Physics.OverlapSphere(transform.position, Payload.ExplosivePayload_Stadistics.explosivepayload_Range);

        foreach(Collider Hits in array_Collider)
        {

            if (Hits.gameObject.CompareTag(VoidLine_Tags.PlayerTags.Player))
            {
                Rigidbody rickbody = Hits.GetComponent<Rigidbody>(); 

                if (rickbody != null)
                {
                    rickbody.AddForce(Vector3.up * Payload.ExplosivePayload_Stadistics.Explosive_Payload_Force);
                    rickbody.AddExplosionForce(Payload.ExplosivePayload_Stadistics.Explosive_Payload_Force, transform.position, Payload.ExplosivePayload_Stadistics.explosivepayload_Range, 0f, ForceMode.Impulse);
                }

            }

        }

        if (other.gameObject.CompareTag(PlayerTags.Player))
        {
            Player_Stats.PlayerHPStatus -= Payload.ExplosivePayload_Stadistics.explosivepayload_Damge_ToPlayer; 
           
        }

        if (other.gameObject.CompareTag(EnemyTags.VoidLine_Enemy))
        {
            VoidLine_EnemyType VoidLineEnemy = other.transform.gameObject.GetComponent<VoidLine_EnemyType>();
            VoidLineEnemy.NewEnemyData.EnemyHP -= Payload.ExplosivePayload_Stadistics.explosivepayload_Damage; 
        }
    }

}
