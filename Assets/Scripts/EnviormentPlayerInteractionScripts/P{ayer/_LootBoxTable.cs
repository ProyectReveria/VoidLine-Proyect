using NUnit.Framework;
using UnityEngine;
using VoidLine_LibaryOfStructures; 
using VoidLine_Tags; 

public class _LootBoxTable : MonoBehaviour
{
    [Header ("Box Data")]
    [SerializeField] VoidLine_LibaryOfStructures.Enviorment_Objects_Loot.Service_LootBox Box_Data;
    [SerializeField] public bool BoxDisapear = false; 

    //NonSerializeData
    private bool isLifepackageHeppn = false; 
    private bool isexplosivepayloadhappen = false;
    private bool ismunicionhappen = false; 

    public void Update()
    {
        //lifepackage
        isLifepackageHeppn =  OverloadOnBoxDestoy_ByPlayer(Box_Data._LifePackage_Prob);

        if (BoxDisapear == true)
        {
            if (isLifepackageHeppn == true)
            {
                GameObject NewLifepackage = Instantiate<GameObject>(Box_Data.LifePackage);
                NewLifepackage.transform.position = Box_Data._LootPosition_AfterBox_Delete; 
                
            }
            Destroy(Box_Data.box); 
        }

    }

    private bool OverloadOnBoxDestoy_ByPlayer(float itemprob)
    {
        bool Answer; 

        float roll = Random.Range(0f, 100f);
        

        if (roll <= itemprob) 
        {
            Answer = true; 
        } else
        {
             Answer = false; 
        }


        return Answer; 
    }
}
