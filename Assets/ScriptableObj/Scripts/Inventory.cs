using UnityEngine;

[CreateAssetMenu(fileName = "InventoryScriptableObject", menuName = "ScriptableObjects/InventoryScriptableObject")]
public class InventoryScriptableObject : ScriptableObject
{
    public int CountOfUpdateMaterial;
    public int CountOfFirstMaterial;
    public int CountOfSecondMaterial;
    public int CountOfThirdMaterial;
}
