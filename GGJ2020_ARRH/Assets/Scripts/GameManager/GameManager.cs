using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int crewNumber = 10;
    [SerializeField]
    private GameObject defaultPirate;

    List<GameObject> crew;
    List<GameObject> enemies;

    public int stage;

    void Start()
    {
        crew = new List<GameObject>();
        for (int i = 0; i < crewNumber; i++)
            crew.Add(Instantiate(defaultPirate));

        InitiateEnemies(10, defaultPirate);

        currentState = GameStates.START;

        stage = 0;
    }

    void Update()
    {
        UpdateState();
    }

    #region game_states
    private int currentState;

    public int GetCurrentState()
    {
        return currentState;
    }
    public void UpdateState()
    {
        switch (currentState)
        {
            case GameStates.START:
                currentState = GameStates.TRANSITION;
                Debug.Log("Entering: TRANSITION");
                break;
            case GameStates.TRANSITION:
                StartCoroutine(Sleep(10));

                stage++;

                // every 4 stages there is a boss
                if (stage % 4 == 0)
                {
                    // TODO mettere un boss
                    InitiateEnemies(10, defaultPirate);
                    currentState = GameStates.BOSS;
                    Debug.Log("Entering: BOSS");
                }
                else
                {
                    // TODO aggiungere scalabilità nelle statistiche
                    InitiateEnemies(10, defaultPirate);
                    currentState = GameStates.BATTLE;
                    Debug.Log("Entering: BATTLE");
                }
                break;
            case GameStates.BATTLE:
            case GameStates.BOSS:
                if (IsCrewDead())
                {
                    currentState = GameStates.GAMEOVER;
                    Debug.Log("Entering: GAMEOVER");
                }
                if (IsEnemiesDead())
                {
                    currentState = GameStates.TRANSITION;
                    Debug.Log("Entering: TRANSITION");
                }
                break;
            case GameStates.GAMEOVER:

                break;
        }
    }

    private IEnumerator Sleep(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
    }
    #endregion

    #region crew
    public bool IsCrewDead()
    {
        foreach (GameObject go in crew)
            if (!go.GetComponent<Pirate>().IsDead())
                return false;
        return true;
    }
    #endregion

    #region enemies
    public bool IsEnemiesDead()
    {
        foreach (GameObject go in enemies)
            if (!go.GetComponent<Pirate>().IsDead())
                return false;
        return true;
    }

    void InitiateEnemies(int crewNumber, GameObject enemyPirate)
    {
        enemies = new List<GameObject>();
        for (int i = 0; i < crewNumber; i++)
            enemies.Add(Instantiate(enemyPirate));
    }
    #endregion
}
