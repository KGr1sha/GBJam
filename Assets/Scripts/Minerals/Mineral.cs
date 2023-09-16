using UnityEngine;

public class Mineral : MonoBehaviour
{
    public delegate void OnMineralMined(string mineralName);
    public static OnMineralMined onMineralMined;

    [SerializeField] private string mineralName;

    public void Mine()
    {
        onMineralMined?.Invoke(mineralName);
        Destroy(this.gameObject);
    }
}
