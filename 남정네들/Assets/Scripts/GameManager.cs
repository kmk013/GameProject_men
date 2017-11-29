using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    public List<GameObject> enemyList = new List<GameObject>();
    private GameObject nowEnemy;
    public bool isPlayerMove = false;
    public GameObject player;

    private GameObject stageText;
    private GameObject timeText;

    public int playerMoveSpeed = 10;
    public int playerRotateSpeed = 100;

    public int point = 0;
    public int stage = 0;
    private float time = 16;

    public GameObject questionPanel;
    public GameObject answerPanel;

    private void Awake()
    {
        GameManager.instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        stageText = GameObject.Find("StageText");
        timeText = GameObject.Find("TimeText");

        NextStage();
    }

    private void Update()
    {
        if (isPlayerMove)
        {
            time -= Time.deltaTime;
            timeText.GetComponent<Text>().text = ((int)time).ToString();
        }
        else
            timeText.GetComponent<Text>().text = "  ";

        if(time <= 0)
        {
            time = 31;
            Destroy(nowEnemy);
            NextStage();
        }
    }

    public void NextStage()
    {
        stage++;
        time += 15;
        isPlayerMove = false;
        StartCoroutine(StageText());
        questionPanel.SetActive(true);
        answerPanel.SetActive(true);

        player.transform.rotation = Quaternion.Euler(0, -90, 0);
        Camera.main.transform.rotation = Quaternion.Euler(0, -90, 0);
        player.transform.position = new Vector3(55, 19, 0);
        Camera.main.transform.position = new Vector3(55, 20.5f, 0);

        MosterSpawn();
    }

    void MosterSpawn()
    {
        GameObject newEnemy = Instantiate(enemyList[Random.Range(0, enemyList.Count)], new Vector3(0, 20, 0), Quaternion.identity) as GameObject;
        nowEnemy = newEnemy;
    }

    IEnumerator StageText()
    {
        stageText.GetComponent<Text>().text = "STAGE " + stage.ToString();
        stageText.SetActive(true);
        yield return new WaitForSeconds(1);
        stageText.SetActive(false);
        yield return null;
    }

    void SaveData()
    {
        PlayerPrefs.SetInt("playerMoveSpeed", playerMoveSpeed);
        PlayerPrefs.SetInt("playerRotateSpeed", playerRotateSpeed);
    }

    void LoadData()
    {
        PlayerPrefs.GetInt("playerMoveSpeed", playerMoveSpeed);
        PlayerPrefs.GetInt("playerRotateSpeed", playerRotateSpeed);
    }
}
