using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    [SerializeField]
    private int crewNumber = 6;
    [SerializeField]
    private GameObject defaultPirate;

    public List<GameObject> crew;

    public List<GameObject> shipsBase;
    public List<GameObject> bossesBase;
    public List<GameObject> ships;
    public List<GameObject> bosses;

    public GameObject enemy;

    public int stage;

    void Start()
    {
        crew = new List<GameObject>();
        for (int i = 0; i < crewNumber; i++)
            crew.Add(Instantiate(defaultPirate));

        ships = new List<GameObject>();
        foreach (GameObject go in shipsBase)
            ships.Add(Instantiate(go));

        bosses = new List<GameObject>();
        foreach (GameObject go in bossesBase)
            bosses.Add(Instantiate(go));

        Debug.Log("ships "+ships.Count);

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
                StartCoroutine(SleepCoroutine(4));
                currentState = GameStates.WAITING_FOR_EVENT;
                break;
            case GameStates.WAITING_FOR_EVENT:
                break;
            case GameStates.BATTLE:
            case GameStates.BOSS:
                if (IsCrewDead())
                {
                    currentState = GameStates.GAMEOVER;
                    Debug.Log("Entering: GAMEOVER");
                }
                if (enemy.GetComponent<Enemy>().IsDead())
                {
                    enemy.SetActive(false);
                    currentState = GameStates.TRANSITION;
                    Debug.Log("Entering: TRANSITION");
                }
                break;
            case GameStates.GAMEOVER:

                break;
        }
    }
    private IEnumerator SleepCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log("after wait for seconds");
        stage++;

        // every 4 stages there is a boss
        if (stage % 4 == 0)
        {
            int index = Random.Range(0, bosses.Count - 1);

            Debug.Log("nemico pescato" + index);
            enemy = bosses[index];
            enemy.GetComponent<Enemy>().Initialize(stage);
            enemy.SetActive(true);

            currentState = GameStates.BOSS;
            Debug.Log("Entering: BOSS");
        }
        else
        {
            int index = Random.Range(0, ships.Count - 1);
            Debug.Log("nemico pescato" + index);
            enemy = ships[index];
            enemy.GetComponent<Enemy>().Initialize(stage);
            enemy.SetActive(true);

            currentState = GameStates.BATTLE;
            Debug.Log("Entering: BATTLE "+currentState);
        }
        foreach (GameObject pirate in crew)
            pirate.GetComponent<Pirate>().CanAttack();

        if (enemy == null)
            Debug.Log("Can't create enemy :(");
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
    public void AttackCrew(float amount)
    {
        int index = Random.Range(0, crew.Count - 1);
        crew[index].GetComponent<Pirate>().TakeDamage(amount);
        if (crew[index].GetComponent<Pirate>().IsDead())
        {
            crew[index].SetActive(false);
            crew.RemoveAt(index);
        }
    }
    #endregion
    #region enemies
    public void AttackEnemy(float amount)
    {
        enemy.GetComponent<Enemy>().TakeDamage(amount);
    }
    #endregion
}
