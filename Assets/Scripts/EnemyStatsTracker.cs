using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyStatsTracker : MonoBehaviour
{
    public bool isTutorial = false;
    public int respawnTime = 300;

    GameObject _enemy = null;
    int _counter;
    IList<EnemyStats> _enemyStatsList;
    EnemyStats _currentEnemyStats;

    void Start()
    {
        _enemyStatsList = new List<EnemyStats>();

        InitializeEnemyList();
        RandomlySummon();
    }

    public void RespawnEnemyIfDead()
    {
        //Respawn
        if (EnemyHealth.Instance.currentHealth <= 0)
        {
            _counter += 1;

            if (_counter == respawnTime)
            {
                if (GameData.Instance.score % 1000 == 0)
                {
                    Summon(5);
                }
                else
                {
                    Summon(UnityEngine.Random.Range(1, 5));
                }

                _counter = 0;
            }
        }
    }

    public void RandomlySummon()
    {
        Summon(UnityEngine.Random.Range(1, 5));
    }

    public void Summon(int enemyNum)
    {
        var enemyName = string.Empty;

        switch (enemyNum)
        {
            case 2:
                enemyName = "Monster2";
                break;
            case 3:
                enemyName = "Monster3";
                break;
            case 4:
                enemyName = "Monster4";
                break;
            case 5:
                enemyName = "Monster5";
                break;
            default:
                enemyName = "Monster1";
                break;
        }

        _currentEnemyStats = _enemyStatsList [enemyNum - 1];
        if (isTutorial)
        {
            _currentEnemyStats = new EnemyStats(1000, Element.Unknown);
        }

        EnemyHealth.Instance.maxHealth = _currentEnemyStats.getHealth();
        EnemyHealth.Instance.currentHealth = _currentEnemyStats.getHealth();

        if (isTutorial)
        {
            enemyName = "TutorialMonster";
        }

        _enemy = (GameObject)Resources.Load(enemyName);
        if (isTutorial)
        {
            Instantiate(_enemy, new Vector3(-10.0f, 0.0f, 0), Quaternion.identity);
            return;
        }

        Instantiate(_enemy, new Vector3(-0.4325213f, 0.0f, 0), Quaternion.identity);
    }

    public void InitializeEnemyList()
    {
        _enemyStatsList.Add(new EnemyStats(10, Element.Plant));
        _enemyStatsList.Add(new EnemyStats(20, Element.Mineral));
        _enemyStatsList.Add(new EnemyStats(15, Element.Fluid));
        _enemyStatsList.Add(new EnemyStats(10, Element.Bone));
        _enemyStatsList.Add(new EnemyStats(50, Element.Unknown));
    }

    public void ReduceEnemyHealth(Element attackWith, int basicDamage)
    {
        var actualDamage = _currentEnemyStats.getDamage(attackWith, basicDamage);

        if (EnemyHealth.Instance.currentHealth - actualDamage <= 0)
        {
            EnemyHealth.Instance.currentHealth = 0;
        }

        else
        {
            EnemyHealth.Instance.currentHealth -= actualDamage;
        }
    }
}
