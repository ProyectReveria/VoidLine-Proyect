
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] public Rigidbody Projct; 
    bool TouchWall = false; 
    [SerializeField] public float Pspeed = 4.0f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IsOnWall"))
        {
            TouchWall = true; 
        }
    }

    void Update()
    {
        Keyboard Kb = Keyboard.current; 
        if (Kb == null) return; 

        if (Kb.rKey.wasPressedThisFrame)
        {
            Rigidbody P_New = Instantiate(Projct, transform.position, transform.rotation);
            P_New.linearVelocity = transform.forward * Pspeed; 
            if (TouchWall == true)
            {
                Destroy(P_New.gameObject);
                TouchWall = false; 
            }
        }
    }
}
