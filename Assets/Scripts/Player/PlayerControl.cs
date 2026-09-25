using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;
using Unity;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{  
    [Header("Sumative Variables for Ligth & Run ")]
    [SerializeField] public float Sumative_Ligth_float ; 
    [SerializeField] public float SumativeRange_Ligth_Float; 

    [SerializeField] private float Sumative_MovementSpeed; 

    [Header("VoidLine Light:Configs")]

    [SerializeField] public float RBaselight ; 
    [SerializeField] public float RDefaultLigth; 
    [SerializeField] public float RLigthLimit; 
   
    [Header ("PlayerControl")]
    //jump & climb
    [SerializeField] private float ClimbSpeed;
    [SerializeField] private float walljumpDirectionalMultiplayer; 
    [SerializeField] private float jumpforce; 
    [SerializeField] private float FallMultiplier; 

    [SerializeField] private float Gravity;

    //movement & camara
    [SerializeField] public float Base_MovementSpeed; 
    [SerializeField] private float BaseOn_RunSpeed; 

    [SerializeField] private float Limit_OnRunSpeed; 
    [SerializeField] private float Camara_Rotation; 
    [SerializeField] private Transform Transform; 
    [SerializeField] private Camera FPcamara; 

    private Vector3 Directional_Movement; 
    private float Rotacion_X_onCamara; 
    private float Rotacion_Y_onCamara;

    [Header("voidLine Variables")]
    [SerializeField] Light PlayerLigth; 
    [SerializeField] float? Life; 
    [SerializeField] GameManager Gmanager; 

//Not Serializable Variables
//______________________________________________________________________________________________________________________________|
    private float Ltime = 0f;                                                                                                      
//______________________________________________________________________________________________________________________________|
    [SerializeField] public float Increased_RunSpeed; 
//______________________________________________________________________________________________________________________________|
    public bool OnFloor;
    public bool OnWallJump; 
//______________________________________________________________________________________________________________________________|
    private Vector3 PositionalJump_OnWallJump; 
//______________________________________________________________________________________________________________________________|
    private Rigidbody rickbody;
//______________________________________________________________________________________________________________________________|


    //Methods

        //Collisions
    private void OnCollisionEnter (Collision On_ObjectCollision)
    {
        if (On_ObjectCollision.gameObject.CompareTag("IsonFloor"))
        {
            OnFloor = true; 
        }

        if (On_ObjectCollision.gameObject.CompareTag("Wall jumpable wall"))
        {
            OnWallJump = true;
            PositionalJump_OnWallJump = On_ObjectCollision.contacts[0].normal; 
        }
    }

    private void OnCollisionExit(Collision On_ObjectCollision)
    {
        if (On_ObjectCollision.gameObject.CompareTag("IsonFloor"))
        {
            OnFloor = false; 
        }

        if (On_ObjectCollision.gameObject.CompareTag("Wall jumpable wall"))
        {
            OnWallJump = false;
        }
    }

    private void OrollerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Wall jumpable wall"))
        {
                Debug.Log("Hit");
        }

    }


    //Player Controls

    void controls()
    {
        Keyboard Controls = Keyboard.current;
        ///<Keyboard>
        /// Unity en el Control.Package requiere de un identificador, eso es Keyboard.
        /// Device.Key.Statement)
        if (Controls == null) return;

        bool OnRun = Controls.leftShiftKey.isPressed; 

        float movx = (Controls.dKey.isPressed || Controls.rightArrowKey.isPressed ? 1f : 0f) - (Controls.aKey.isPressed || Controls.leftArrowKey.isPressed ? 1f : 0f);
        float movz = (Controls.wKey.isPressed || Controls.upArrowKey.isPressed ? 1f : 0f) - (Controls.sKey.isPressed || Controls.downArrowKey.isPressed ? 1f : 0f);

        bool moving = movx != 0f || movz != 0f;

        Directional_Movement = transform.right * movx + transform.forward * movz; 

        //ligth & sprint
        Ltime += Time.deltaTime; 
        if ( moving == true && OnRun == true )
        {
            if (Ltime >= 0.1f)
            {
                if (Increased_RunSpeed < Limit_OnRunSpeed)
                {
                    Increased_RunSpeed = Increased_RunSpeed + Sumative_MovementSpeed; 
                } 
                else if (Increased_RunSpeed >= Limit_OnRunSpeed)
                {
                    Increased_RunSpeed = Limit_OnRunSpeed; 
                }

                if (PlayerLigth.range < RLigthLimit)
                {
                    PlayerLigth.range += SumativeRange_Ligth_Float;
                } 
                else if (PlayerLigth.range >= RLigthLimit)
                {
                    PlayerLigth.range = RLigthLimit; 
                }

                if (PlayerLigth.intensity < RLigthLimit)
                {
                    PlayerLigth.intensity += Sumative_Ligth_float;
                } 
                else if (PlayerLigth.intensity >= RLigthLimit)
                {
                    PlayerLigth.intensity = RLigthLimit; 
                }

                Ltime = 0; 
            }

            Vector3 targetVelocity = Directional_Movement * Increased_RunSpeed;
            Vector3 currentVelocity = rickbody.linearVelocity;
            
            targetVelocity.x = Mathf.Lerp(currentVelocity.x, targetVelocity.x, Time.deltaTime * 4f);
            targetVelocity.z = Mathf.Lerp(currentVelocity.z, targetVelocity.z, Time.deltaTime * 4f);
            targetVelocity.y = currentVelocity.y;
            
            rickbody.linearVelocity = targetVelocity;  
        } 
        
        if (moving == true && OnRun == false)
        {
            if (Ltime >= 0.1f)
            {
                if (Increased_RunSpeed > Base_MovementSpeed)
                {
                    Increased_RunSpeed = Increased_RunSpeed - Sumative_MovementSpeed; 
                } 
                else
                {
                    Increased_RunSpeed = Base_MovementSpeed; 
                }

                if (PlayerLigth.range > RBaselight)
                {
                    PlayerLigth.range -= SumativeRange_Ligth_Float;
                } 
                else if (PlayerLigth.range <= RBaselight)
                {
                    PlayerLigth.range = RBaselight;
                }

                if (PlayerLigth.intensity > RBaselight)
                {
                    PlayerLigth.intensity -= Sumative_Ligth_float;
                }
                else if (PlayerLigth.intensity <= RBaselight)
                {
                    PlayerLigth.intensity = RBaselight;
                }

                Ltime = 0; 
            }
 
            Vector3 targetVelocity = Directional_Movement * Increased_RunSpeed;
            Vector3 currentVelocity = rickbody.linearVelocity;
            
            targetVelocity.x = Mathf.Lerp(currentVelocity.x, targetVelocity.x, Time.deltaTime * 4f);
            targetVelocity.z = Mathf.Lerp(currentVelocity.z, targetVelocity.z, Time.deltaTime * 4f);
            targetVelocity.y = currentVelocity.y;
            
            rickbody.linearVelocity = targetVelocity;  
        }

        if (moving == false)
        {
            if (Ltime >= 0.1f)
            {
                if (PlayerLigth.intensity > RBaselight)
                {
                    PlayerLigth.intensity -= Sumative_Ligth_float;
                } 
                else if (PlayerLigth.intensity <= RBaselight)
                {
                    PlayerLigth.intensity = RBaselight;
                }

                if (PlayerLigth.range > RBaselight)
                {
                    PlayerLigth.range -= SumativeRange_Ligth_Float;
                } 
                else if (PlayerLigth.range <= RBaselight)
                {
                    PlayerLigth.range = RBaselight;
                }
                
                if (Increased_RunSpeed > Base_MovementSpeed)
                {
                    Increased_RunSpeed = Increased_RunSpeed - Sumative_MovementSpeed; 
                } 
                else
                {
                    Increased_RunSpeed = Base_MovementSpeed; 
                }

                Ltime = 0; 
            }

            Vector3 currentVelocity = rickbody.linearVelocity;
            currentVelocity.x = Mathf.Lerp(currentVelocity.x, 0f, Time.deltaTime * 4f);
            currentVelocity.z = Mathf.Lerp(currentVelocity.z, 0f, Time.deltaTime * 4f);
            rickbody.linearVelocity = currentVelocity;
        }
    }

    void jump()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        bool spaceDown = kb.spaceKey.wasPressedThisFrame;
        bool spaceHeld = kb.spaceKey.isPressed;

        if (spaceDown && !OnFloor && OnWallJump)
        {
            Vector3 vel = rickbody.linearVelocity; 
            vel.y = 0f; 
            rickbody.linearVelocity = vel; 

            Vector3 pushAway = PositionalJump_OnWallJump;
            pushAway.y = 0f;

            Vector3 finalImpulse = (Vector3.up * jumpforce) + (pushAway * (jumpforce * walljumpDirectionalMultiplayer));
            rickbody.AddForce(finalImpulse, ForceMode.Impulse);
        } 

        else if (spaceHeld && !OnFloor && OnWallJump)
        {
            Vector3 vel = rickbody.linearVelocity; 
            vel.y = ClimbSpeed; 
            rickbody.linearVelocity = vel; 
        }   

        else if (spaceDown && (OnFloor || Mathf.Abs(rickbody.linearVelocity.y) < 0.01f))
        {
            Vector3 vel = rickbody.linearVelocity; 
            vel.y = 0f; 
            rickbody.linearVelocity = vel; 

            rickbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse); 
            OnFloor = false;
        }
    }

    //Camara Controls
    void Camara_Controler()
    {
        Mouse mouse = Mouse.current;
        if (mouse == null) return;

        Vector2 mouseDelta = mouse.delta.ReadValue();
        float Ratonx = mouseDelta.x * Camara_Rotation * 0.02f;
        float RatonY = mouseDelta.y * Camara_Rotation * 0.02f; 

        Rotacion_X_onCamara -= RatonY; 
        Rotacion_X_onCamara = Mathf.Clamp(Rotacion_X_onCamara, -90f, 90f); 

        FPcamara.transform.localRotation = Quaternion.Euler(Rotacion_X_onCamara, 0, 0); 
        transform.Rotate(Vector3.up * Ratonx); 
    }

    //Update & awake & FixedUpdate
    void Awake()
    {
        Increased_RunSpeed = BaseOn_RunSpeed; 
        rickbody = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        controls(); 
        jump();
        Camara_Controler(); 
    }
}