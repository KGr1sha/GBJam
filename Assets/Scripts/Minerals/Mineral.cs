using System.Collections;
using UnityEngine;

public class Mineral : MonoBehaviour, IMinable
{
    public delegate void OnMineralMined(string mineralName, int amount);
    public static OnMineralMined onMineralMined;

    [SerializeField] private int maxHealth;
    [SerializeField] private string mineralName;
    [SerializeField] private int gemsToGive;

    private Animator animationController;
    private int health;
    private bool isBeingMined;

    private void Start()
    {
        health = maxHealth;
        animationController = GetComponent<Animator>();
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
        animationController.speed = 1;
        animationController.SetTrigger("IsMining");
    }

    public void StopMining()
    {
        isBeingMined = false;
        if (animationController != null)
            animationController.speed = 0;
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
