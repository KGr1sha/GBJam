using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryScriptableObject inventory;
    [SerializeField] private UI uiPanel;

    private void OnEnable()
    {
        Mineral.onMineralMined += AddItem;
    }

    private void OnDisable()
    {
        Mineral.onMineralMined -= AddItem;
    }

    private void Start()
    {
        ClearInventory();
    }

    private void ClearInventory()
    {
        inventory.gem1 = 0;
        inventory.gem2 = 0;
        inventory.gem3 = 0;
    }

    private void AddItem(string itemName, int amount)
    {
        switch (itemName)
        {
            case "gem1":
                inventory.gem1 += amount;
                uiPanel.SetInventoryCount(inventory.gem1);
                break;

            case "gem2":
                inventory.gem2 += amount;
                break;

            case "gem3":
                inventory.gem3 += amount;
                break;
        }
    }
}
