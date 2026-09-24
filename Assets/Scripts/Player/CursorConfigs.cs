using UnityEngine;



public class CursorConfigs : MonoBehaviour
{
    [SerializeField] private bool CursorActive; 

    void Start()
    {
        Cursor.visible = CursorActive; 
        Cursor.lockState = CursorLockMode.Locked; 
    }
}
