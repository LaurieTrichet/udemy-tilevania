using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyReferenceSO enemyReferenceSO;
    // Start is called before the first frame update
    void Start()
    {
        enemyReferenceSO.ReloadEnemies();
    }
}
