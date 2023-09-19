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
        Debug.Log("Mining " + mineralName);
        StartCoroutine(MiningTimer());
        isBeingMined = true;
    }

    public void StopMining()
    {
        isBeingMined = false;
        Debug.Log("Not mining");
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
