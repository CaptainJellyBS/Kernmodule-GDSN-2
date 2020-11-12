using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public float correctCode, buggedCode, timeBetweenSteps;
    public float timeBetweenBugsMin, timeBetweenBugsMax;
    public GameObject bug;

    public ScoreUI goodCode, badCode, endScore;

    public static GameManager Instance { get; private set; }
    public UnityEvent deathEvents, winEvents;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnBugs());
        StartCoroutine(ImproveCode());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.End)) { Win(); }
    }

    public void TakeDamage(float damage)
    {
        float actualDamage = Mathf.Min(damage, correctCode);
        correctCode -= actualDamage;
        buggedCode += actualDamage;
        buggedCode = Mathf.Max(0.0f, buggedCode);
        UpdateScores();
    }

    IEnumerator SpawnBugs()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(timeBetweenBugsMin, timeBetweenBugsMax));
            Instantiate(bug, generateRandomSpawnPos(), Quaternion.identity);
        }
    }

    IEnumerator ImproveCode()
    {
        while(correctCode+buggedCode < 1.0f)
        {
            yield return new WaitForSeconds(timeBetweenSteps);
            correctCode += 0.01f;
            UpdateScores();
        }

        Win();
    }

    Vector3 generateRandomSpawnPos()
    {
        float y = Random.Range(2.5f, 9.0f);
        float x = Random.Range(10.0f, 14.0f);
        float z = Random.Range(-14.0f, 14.0f);

        if (Random.Range(0, 2) == 1) { x *= -1; }

        return new Vector3(x, y, z);
    }

    void UpdateScores()
    {
        goodCode.ScoreValue = (int)(correctCode * 100);
        badCode.ScoreValue = (int)(buggedCode * 100);
        endScore.ScoreValue = (int)(correctCode * 100);
    }

    #region ManaBasic Functionality
    public void Die()
    {
        deathEvents.Invoke();
    }

    public void Win()
    {
        winEvents.Invoke();
    }
    #endregion
}
