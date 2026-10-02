using UnityEngine;

public class ExplosivePayloadSencore : MonoBehaviour
{

    [Header ("ExplosivePayloadScript")]
    [SerializeField] private TheExplosivePackageScriptTest Payload;

    void OnTriggerEnter(Collider other)
    {
        Payload.isoncollide = true;
    }

    void OTriggerExit(Collider other)
    {
        Payload.isoncollide = false;
    }
}
