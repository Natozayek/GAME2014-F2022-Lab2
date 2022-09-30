using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Range(1, 5)]
    public int enemyNumber = 3;
    public GameObject enemyPrefab;
    public List<GameObject> enemyList;

    // Start is called before the first frame update
    void Start()
    {
        BuildEnemyList();
    }

    private void BuildEnemyList()
    {
        for (int i = 0; i < enemyNumber; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            enemyList.Add(enemy);
        }
    }

}
