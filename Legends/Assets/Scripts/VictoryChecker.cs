using UnityEngine;

public class VictoryChecker : MonoBehaviour
{
    public GameObject victoryPanel; // Assign in Inspector

    void Update()
    {
        // Get all GameObjects tagged "Enemie"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemie");

        // Early return if there are no enemies
        if (enemies.Length == 0) return;

        // Check if ALL enemies are dead
        foreach (GameObject enemyObj in enemies)
        {
            Enemy enemy = enemyObj.GetComponent<Enemy>();
            if (enemy != null && !enemy.isDead)
            {
                return; // At least one enemy is still alive
            }
        }

        // All enemies are dead
        victoryPanel.SetActive(true);
        enabled = false; // Stop checking
    }
}