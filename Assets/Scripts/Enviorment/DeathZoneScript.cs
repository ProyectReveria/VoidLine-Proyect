using Unity.VisualScripting;
using UnityEngine;

public class DeathZoneScript : MonoBehaviour
{
    [SerializeField] PlayerHPandStadistics playerstadistics;

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            playerstadistics.PlayerHPStatus = 0; 
        }
    }

}
