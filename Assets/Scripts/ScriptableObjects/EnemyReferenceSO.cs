using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "EnemyReference", menuName = "ScriptableObjects/EnemyReference")]
public class EnemyReferenceSO : ScriptableObject
{
    private EnemyMovement[] enemies = null;
    // Start is called before the first frame update
    public void ReloadEnemies()
    {
        enemies = FindObjectsOfType<EnemyMovement>();
    }

    public void DesactivateEnemies()
    {
        enemies.ToList().ForEach((enemyMovement) =>
        {
            enemyMovement.isActivated = false;
        });
    }
}
