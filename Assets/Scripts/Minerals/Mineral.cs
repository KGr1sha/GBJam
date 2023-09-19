using System.Collections;
using UnityEngine;

public class Mineral : MonoBehaviour, IMinable
{
    public delegate void OnMineralMined(string mineralName, int amount);
    public static OnMineralMined onMineralMined;

    [SerializeField] private int maxHealth;
    [SerializeField] private string mineralName;
    [SerializeField] private int gemsToGive;
    private int health;
    private bool isBeingMined;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            onMineralMined?.Invoke(mineralName, gemsToGive);
        }
    }

    public void StartMining()
    {
        StartCoroutine(MiningTimer());
        isBeingMined = true;
        Debug.Log("Mining " + mineralName);
    }

    public void StopMining()
    {
        isBeingMined = false;
    }

    private IEnumerator MiningTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (isBeingMined)
                TakeDamage(1);
            else
                break;
        }
    }
}
