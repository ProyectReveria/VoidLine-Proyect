
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] public WeaponManager Wmanager; 
    bool TouchWall = false; 
    [SerializeField] public float Pspeed = 4.0f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IsonWall"))
        {
            TouchWall = true; 
        }
    }

    void Update()
    {
        Keyboard Kb = Keyboard.current; 
        if (Kb == null) return; 

        if (Kb.qKey.wasPressedThisFrame)
        {
            if(Wmanager.weapon1_Active == true)
            {
                Wmanager.weapon1_Active = false;
                Wmanager.Weapond2_Active = true; 
            }else if(Wmanager.weapon1_Active == false)
            {
                Wmanager.weapon1_Active = true;
                Wmanager.Weapond2_Active = false; 
            }
        }

        if (Kb.rKey.wasPressedThisFrame && Wmanager.weapon1_Active == true)
        {
            Rigidbody P_New = Instantiate(Wmanager.Proyectile_1, transform.position, transform.rotation);
            P_New.linearVelocity = transform.forward * Pspeed; 
            if (TouchWall == true)
            {
                Destroy(P_New.gameObject);
                TouchWall = false; 
            }
        }else if (Kb.rKey.wasPressedThisFrame && Wmanager.Weapond2_Active == true)
        {
            Rigidbody P_New = Instantiate(Wmanager.Projectile_2, transform.position, transform.rotation);
            P_New.linearVelocity = transform.forward * Pspeed; 
            if (TouchWall == true)
            {
                Destroy(P_New.gameObject);
                TouchWall = false; 
            }
        }
    }
}
