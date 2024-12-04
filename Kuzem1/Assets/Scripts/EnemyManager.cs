using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemyPrefab;
    public Enemy bossEnemyPrefab;
    public Enemy fastEnemyPrefab;
    public Enemy shootingEnemyPrefab;
    public GameDirector gameDirector;

    public float enemyYSpacing = 2;
    public Transform enemyParent;

    [SerializeField] int spawnEnemyCount;

    [SerializeField] Player player;

    [SerializeField] int totalEnemy;

    [SerializeField] List<Enemy> enemies = new List<Enemy>();

    Coroutine enemyGenerationCoroutine;
    public void ReStartEnemyManager()
    {
        DeleteEnemies();

        if (enemyGenerationCoroutine != null)
        {
            StopCoroutine(enemyGenerationCoroutine);
        }
        enemyGenerationCoroutine = StartCoroutine(EnemyGererationCoroutine());

        spawnEnemyCount = 0;

        //SpawnEnemies();
    }

    void DeleteEnemies()
    {
        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
        enemies.Clear();

    }

    IEnumerator EnemyGererationCoroutine()
    {
        while(true)
        {
            float randomSpawnWait = Random.Range(1f, 2f);
            yield return new WaitForSeconds(randomSpawnWait);

            int enemyCountBonus = totalEnemy + (gameDirector.levelNo - 5) * 5;
            enemyCountBonus = Mathf.Min(enemyCountBonus);

            if (spawnEnemyCount < enemyCountBonus)
            {
                if (Random.value < .75f)
                {
                    SpawnNewEnemy(-2f, 2f);
                }
                else
                {
                    SpawnTwoEnemies();
                }
            }

            else
            {
                yield return new WaitForSeconds(3f);
                SpawnBoss();
                break;
            }
           

        }
    }

    void SpawnNewEnemy(float minXpos,float maxXpos)
    {

        var selectedEnemyPrefab = enemyPrefab;
        var randomizer = Random.value;
        if (gameDirector.levelNo > 2 && randomizer < .33f)
        {
            selectedEnemyPrefab = fastEnemyPrefab;
        }
        else if (gameDirector.levelNo > 3 && randomizer < .66f)
        {
            selectedEnemyPrefab = shootingEnemyPrefab;
        }
        var newEnemy = Instantiate(selectedEnemyPrefab);
        float enemyXPos = Random.Range(minXpos, maxXpos);
        float enemyYPos = 4 * enemyYSpacing;
        newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos, 0);
        newEnemy.StartEnemy(player);
        enemies.Add(newEnemy);
        
        spawnEnemyCount++;

    }

    void SpawnTwoEnemies()
    {
        SpawnNewEnemy(1f,2.2f);

        SpawnNewEnemy(-2.2f,-1f);
    }

    void SpawnBoss()
    {
        var newEnemy = Instantiate(bossEnemyPrefab, enemyParent);
        float enemyXPos = Random.Range(-2f, 2f);
        float enemyYPos = 4 * enemyYSpacing;
        newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos, 0);
        newEnemy.StartEnemy(player);
        enemies.Add(newEnemy);

    }
}
