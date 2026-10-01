using UnityEngine;
using UnityEngine.InputSystem;

public class GameWeaponTestFromCamara : MonoBehaviour
{
    [Header ("@GameManager")]
    
    [SerializeField] private GameManager @GameManajer; 
    
    [Header ("LayerMask")]

    [SerializeField] private LayerMask Player_Mask; 

    [Header ("Camara Geme Object")]

    [SerializeField] private Camera PlayerCamara; 

    [Header ("Weapond Stats")]

    [SerializeField] private int weapond_Amunition; 
    [SerializeField] private float Weapon_Damage;

    void Update()
    {
        //variables
        Mouse Raton = Mouse.current; 
        RaycastHit hit; 
        //code
        if (Raton == null){return;}
        Ray Gun_Ray = new Ray(PlayerCamara.transform.position, PlayerCamara.transform.forward); 

        if (Raton.leftButton.wasPressedThisFrame)
        {
            if (Physics.Raycast(Gun_Ray, out hit, 60, ~Player_Mask))
            {
                if (hit.transform.gameObject.CompareTag("Enemy_Voidline"))
                {
                    Debug.Log("EnemyVoidline"); 
                }
            }
        }


    }
}
