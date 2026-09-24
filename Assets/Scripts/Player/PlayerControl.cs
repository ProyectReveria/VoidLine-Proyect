using System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{  
    [Header("Movement Control Seting")]
    [SerializeField] private float VelocidadDelantera; // ------->
    [SerializeField] private float velocidadtrasera;   // <-------

    [Header("Sumative Variables for Ligth & Run ")]
    [SerializeField] public float Sumative_Ligth_float ; 
    [SerializeField] public float SumativeRange_Ligth_Float; 

    [SerializeField] private float Sumative_MovementSpeed; 

    [Header("VoidLine Light:Configs")]

    [SerializeField] public float RBaselight ; 
    [SerializeField] public float RDefaultLigth; 
    [SerializeField] public float RLigthLimit; 
   
    [Header ("PlayerControl")]
    //jump
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
//______________________________________________________________________________________________________________________________|

//______________________________________________________________________________________________________________________________|
    private Rigidbody rickbody;
//______________________________________________________________________________________________________________________________|


    //Methods
    private void OnCollisionEnter (Collision Floor)
    {
        if (Floor.gameObject.CompareTag("IsonFloor"))
        {
            OnFloor = true; 
        }
        
    }

    private void OnCollisionExit(Collision Floor)
    {
        if (Floor.gameObject.CompareTag("IsonFloor"))
        {
            OnFloor = false; 
        }
    }
    
    //Player Controls

    void controls()
    {
        bool moving = Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f;
        bool OnRun = Input.GetKey(KeyCode.LeftShift); 
        bool OnJump = Input.GetKey(KeyCode.Space); 

        float movx = Input.GetAxis("Horizontal"); //Recordar que "Horizontal | "Vertical" en unity implian Axis de X y Y en un Vector [x,y]. 
        ///<Formula>
        ///  [x,y] = [
        ///         X + input{input = N + 1 or  N - 1}
        ///         Y + input{input = N + 1 or N - 1}
        ///         ]
        /// on Vectorial Space
        float movz = Input.GetAxis("Vertical"); 

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
                     
                } else if (Increased_RunSpeed >= Limit_OnRunSpeed)
                {
                    Increased_RunSpeed = Limit_OnRunSpeed; 
                    
                }

                if (PlayerLigth.range < RLigthLimit)
                {
                    PlayerLigth.range += SumativeRange_Ligth_Float;
                } else if (PlayerLigth.range >= RLigthLimit)
                {
                    PlayerLigth.range = RLigthLimit; 
                }

                if (PlayerLigth.intensity < RLigthLimit)
                {
                    PlayerLigth.intensity += Sumative_Ligth_float;
                } else if (PlayerLigth.intensity >= RLigthLimit)
                {
                    PlayerLigth.intensity = RLigthLimit; 
                }

                Ltime = 0; 

            }

            Vector3 targetVelocity = Directional_Movement * Increased_RunSpeed;
            Vector3 currentVelocity = rickbody.linearVelocity;
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
            targetVelocity.y = currentVelocity.y;
            rickbody.linearVelocity = targetVelocity;  

        }

        if ( moving == false)
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

        }
        
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (OnFloor || Mathf.Abs(rickbody.linearVelocity.y) < 0.01f))
        {
            Vector3 vel = rickbody.linearVelocity; 
            vel.y = 0f; 
            rickbody.linearVelocity = vel; 

            rickbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse ); 
            OnFloor = false;
        }
    }
            //Camara Controls


    void Camara_Controler()
    {
        float Ratonx = Input.GetAxis("Mouse X") * Camara_Rotation;
        float RatonY = Input.GetAxis("Mouse Y") * Camara_Rotation; 

        Rotacion_X_onCamara -= RatonY; 
        Rotacion_X_onCamara = Mathf.Clamp(Rotacion_X_onCamara, -90f, 90f); 

        

        
        FPcamara.transform.localRotation = Quaternion.Euler(Rotacion_X_onCamara, 0,0); 

        ///<Quaternions>
        /// podemos definir algebraicamente que un cuaternion es:
        /// 
        /// [
        /// X = Cx *
        ///  CY, Y = sx * sy *sz
        /// ]
        /// 
        /// [X] + [Y]
        /// 
        /// Tambien digase que Cx es un conjunto de Senos y CY de cosenos 
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