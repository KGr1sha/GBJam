using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryScriptableObject inventory;

    private void OnEnable()
    {
        Mineral.onMineralMined += AddItem;
    }

    private void OnDisable()
    {
        Mineral.onMineralMined -= AddItem;
    }

    private void AddItem(string itemName)
    {
        switch (itemName)
        {
            case "gem1":
                inventory.gem1 += 1;
                break;

            case "gem2":
                inventory.gem2 += 1;
                break;

            case "gem3":
                inventory.gem3 += 1;
                break;
        }
    }
}
