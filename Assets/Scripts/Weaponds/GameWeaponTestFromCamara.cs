using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using VoidLine_LibaryOfStructures; 
public class GameWeaponTestFromCamara : MonoBehaviour
{
    [Header ("@GameManager")]
    
    [SerializeField] private GameManager @GameManajer; 
    [SerializeField] private WeaponManager @weaponmanager; 
    
    [Header ("LayerMask")]

    [SerializeField] private LayerMask Player_Mask; 

    [Header ("Camara Geme Object")]

    [SerializeField] private Camera PlayerCamara; 

    [Header ("Weapond Stats")]

    [SerializeField] public EquipablesTools.Weapond_Stats Weapon_Stats;
    //normal variables
    public int Mag; 
    public bool isreloding; 

    //start
    void Start()
    {
        Mag = Weapon_Stats.magazing; 
    }

    void Update()
    {
        Weapon_Accion(); 
        weaponchange();
    }

    void weaponchange()
    {
        Keyboard ky = Keyboard.current; 
        if (ky== null){return;}

        if (ky.digit1Key.wasPressedThisFrame)
        {
            weaponmanager.weapon1_Active = true;
            weaponmanager.Weapond2_Active = false;
        }

        if (ky.digit2Key.wasPressedThisFrame)
        {
            weaponmanager.weapon1_Active = false;
            weaponmanager.Weapond2_Active = true;
        }
    }

    void Weapon_Accion()
    {
                //variables
        Mouse Raton = Mouse.current; 
        Keyboard ky = Keyboard.current; 
        if (Raton == null || ky == null) { return;}
        RaycastHit hit; 
        //Weapond

        //delta
        float time = Time.deltaTime; 
        //code      
        if (Raton == null){return;}
        Ray Gun_Ray = new Ray(PlayerCamara.transform.position, PlayerCamara.transform.forward); 

        if (Raton.leftButton.wasPressedThisFrame)
        {
            if (Physics.Raycast(Gun_Ray, out hit, 60, ~Player_Mask))
            {
                if (hit.transform.gameObject.CompareTag("Enemy_Voidline") && isreloding == false && weaponmanager.weapon1_Active == true)
                {
                    if (Mag <= 0)
                    {
                        StartCoroutine(reload()); 
                        return; 
                    }
                    --Mag; 

                    Debug.Log("EnemyVoidline"); 

                    VoidLine_EnemyType VoidLineEnemy =   hit.transform.gameObject.GetComponent<VoidLine_EnemyType>(); 

                    VoidLineEnemy.NewEnemyData.EnemyHP -= Weapon_Stats.damaga; 
                    
                } else if (hit.transform.gameObject.CompareTag("Enemy_Voidline") == false&& isreloding == false && weaponmanager.weapon1_Active == true)
            {
                    if (Mag <= 0)
                    {
                        StartCoroutine(reload()); 
                        return; 
                    }
                    --Mag; 
            }
            }
        }
        if (ky.rKey.wasPressedThisFrame && isreloding == false && Mag != Weapon_Stats.magazing)
        {
            StartCoroutine(reload()); 
            return; 
        }
    }

    private IEnumerator reload()
    {
        isreloding = true; 
        Debug.Log("Reloading");
        yield return new WaitForSeconds(Weapon_Stats.reloadTime); 
        Mag = Weapon_Stats.magazing; 
        isreloding = false; 
        
    }
}
