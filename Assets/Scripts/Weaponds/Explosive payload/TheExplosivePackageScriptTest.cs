using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using VoidLine_LibaryOfStructures; 

public class TheExplosivePackageScriptTest : MonoBehaviour
{
    [Header ("ExplosivePackAgeHitbox")]

    [SerializeField] GameObject explosivepayload;
    [Header("Payload Configs")]
    [SerializeField] public VoidLine_LibaryOfStructures.EquipablesTools.Explosive_Payload ExplosivePayload_Stadistics; 
    [SerializeField] private ExplosivePayloadSencore sensor; 

    [SerializeField] public bool isoncollide = false; 

    [Header ("Player")]
    [SerializeField] Rigidbody rickbody;
    [SerializeField] LayerMask Playermask; 
    [SerializeField] GameObject Player; 
    [SerializeField] Camera PlayerCamara; 
    [SerializeField] PlayerHPandStadistics Player_Stadistics;
    

    //Not SF variables

    private bool CanUsePayload = true;
    public int ActualAmountofPayloads;

    void Awake()
    {
        ActualAmountofPayloads = ExplosivePayload_Stadistics.Payload_Inventory;
    }

    void Update()
    {
        explosivepayload_Use();
    }

    void explosivepayload_Use()
    {
        Keyboard ky = Keyboard.current; 
        if (ky == null) { return; }

        if (ky.eKey.wasPressedThisFrame && ActualAmountofPayloads > 0 && CanUsePayload && ActualAmountofPayloads < 0) 
        {
            --ExplosivePayload_Stadistics.Payload_Inventory; 
            Ray PayloadRay = new Ray(PlayerCamara.transform.position, PlayerCamara.transform.forward); 
            RaycastHit hit; 
            if (Physics.Raycast(PayloadRay, out hit, 40, ~Playermask))
            {
                Vector3 RaycastHit = hit.point; 
                GameObject New_Payload = Instantiate(explosivepayload,hit.point, Player.transform.rotation ); 
                StartCoroutine(PayloadCooldown()); 
                Destroy(New_Payload,2f);  
            }
        }
    }

    private IEnumerator PayloadCooldown()
    {
        CanUsePayload = false; 
        yield return new WaitForSeconds(ExplosivePayload_Stadistics.TimeBetweenPayload);
        CanUsePayload = true; 
    }

}
