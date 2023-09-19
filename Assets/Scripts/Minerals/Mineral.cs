using System.Collections;
using UnityEngine;

public class Mineral : MonoBehaviour, IMinable
{
    public delegate void OnMineralMined(string mineralName);
    public static OnMineralMined onMineralMined;

    [SerializeField] private int maxHealth;
    [SerializeField] private string mineralName;
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
            onMineralMined?.Invoke(mineralName);
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
