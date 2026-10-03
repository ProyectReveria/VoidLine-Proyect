using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using VoidLine_LibaryOfStructures; 

public class TheExplosivePackageScriptTest : MonoBehaviour
{
    [Header ("ExplosivePackAgeHitbox")]

    [SerializeField] GameObject explosivepayload;
    [Header("Payload Configs")]
    [SerializeField] VoidLine_LibaryOfStructures.EquipablesTools.Explosive_Payload ExplosivePayload_Stadistics; 

    [SerializeField] public bool isoncollide = false; 

    [Header ("Player")]
    [SerializeField] Rigidbody rickbody;
    [SerializeField] LayerMask Playermask; 
    [SerializeField] GameObject Player; 
    [SerializeField] Camera PlayerCamara; 
    [SerializeField] PlayerHPandStadistics Player_Stadistics;

    //Not SF variables

    void Update()
    {
        explosivepayload_Use();
        
    }





    void explosivepayload_Use()
    {
        Keyboard ky = Keyboard.current; 
        if (ky == null) { return; }

        if (ky.eKey.wasPressedThisFrame)
        {
            Ray PayloadRay = new Ray(PlayerCamara.transform.position, PlayerCamara.transform.forward); 
            RaycastHit hit; 
            if (Physics.Raycast(PayloadRay, out hit, 40, ~Playermask))
            {

                Vector3 RaycastHit = hit.point; 

                GameObject New_Payload = Instantiate(explosivepayload,hit.point, Player.transform.rotation ); 
                if ( isoncollide == true)
                {
                    Vector3 vel = rickbody.linearVelocity; 
                    vel.y = 0f; 
                    rickbody.linearVelocity = vel; 

                    rickbody.AddForce(Vector3.up * ExplosivePayload_Stadistics.Explosive_Payload_Force, ForceMode.Impulse); 
                }
                Destroy(New_Payload,2f);  
            }
        }
    }

}
