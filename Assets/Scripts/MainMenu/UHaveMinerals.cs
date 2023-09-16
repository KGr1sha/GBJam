using UnityEngine;
using TMPro;

public class UHaveMinerals : MonoBehaviour
{
    [SerializeField] TMP_Text uHaveMin;
    [SerializeField] InventoryScriptableObject Invetary;
    [SerializeField] int idOfMin;

    public void Update()
    {   
        switch (idOfMin)
        {   
            case 0:
                uHaveMin.text = Invetary.CountOfUpdateMaterial.ToString();
                break;
            case 1:
                uHaveMin.text = Invetary.CountOfFirstMaterial.ToString();
                break;
            case 2:
                uHaveMin.text = Invetary.CountOfSecondMaterial.ToString();
                break;
            case 3:
                uHaveMin.text = Invetary.CountOfThirdMaterial.ToString();
                break;
        }
        
    }

}
