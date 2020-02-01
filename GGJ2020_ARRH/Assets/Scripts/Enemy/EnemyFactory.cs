using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    #region singleton
    public static EnemyFactory Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    public GameObject enemyPrefab;

    public GameObject CreateEnemy(int stage)
    {
        GameObject go = Instantiate(enemyPrefab);

        // TODO aggiungere scalabilita'

        return go;
    }
    public GameObject CreateBoss(int stage)
    {
        GameObject go = Instantiate(enemyPrefab);

        // TODO aggiungere scalabilita'

        return go;
    }
}
