using UnityEngine;

public class WeapondRailCast : MonoBehaviour
{
    [Header ("Weapon Configs")]

    [Header ("Weapon DAta For Railcast")]
    [SerializeField] Camera player_camara; 
    [SerializeField] GameObject weapond;
    
    //raycast
    void Update()
    {
        //WeapondPosition
        RaycastHit hit;
        //WeaponPosition 
        Vector3 Position = 
        weapond.transform.position = player_camara.transform.position;

        Ray RailCast_Weapond = new Ray(weapond.transform.position, weapond.transform.forward);

        if (Physics.Raycast(RailCast_Weapond, out hit))
        {
            Debug.Log("Distancia: " + hit.distance);
            Debug.Log("punto de impacto" + hit.point); 

            hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.green; 
        }
        
        
    }



}
