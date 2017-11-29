using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    protected int id = 0;
    protected int answerId = 0;
    
    public Text questionText;
    public Button[] answerButton = new Button[3];
    
    [SerializeField]
    public Material angryMaterial;

    protected bool isAngry;
    protected bool isInstantiate;
    protected float speed = 50;

    protected Vector3 target;

    public string[] question = new string[21]{
        "난 동연이야\n내가 내년에 모콘을 나갈 껀데 무슨 역할로 나갈까?",
        "난 자민이야\n일을 하러 갈껀데 어디로 갈까?",
        "난 민규야\n밥을 먹을려 하는데 몇 공기를 먹으면 좋을까?",
        "난 민땡이야\n커뮤니티를 하려 하는데 무슨 사이트에 들어갈까?",
        "난 킹갓제너럴엠퍼러세계의지배자김준수야\n누구를 먼저 죽이면 좋을까?",
        "난 창현이야\n김준수?",
        "난 승훈이야\n아ㅏㅏㅏ아아아아아아아ㅏ아아아",
        "난 지호야\n능반이?",
        "난 용호야\n반준수?",
        "난 준석이야\n띠용?",
        "난 민재야\n몰라",
        "난 정원이야\n우끼끼",
        "난 성빈이야\n날 죽여줘",
        "난 새영이야\n서울대",
        "난 성민이야\n아ㅏㅏㅏㅏㅏㅏ재",
        "난 주호야\n무슨 색깔로 염색을 할까?",
        "난 한수야\n친구 있어?",
        "난 지환이야\n뭐가 좋아?",
        "난 승현이야\n어떤 애가 좋아?",
        "난 나단이야\n너의 이름은?",
        "난 재현이야\n언제 잘꺼야?"
        };
    public string[,] answer = new string[21, 3] {
        { "기획자", "개발자", "디자이너"},
        { "도넛가게", "자민엔터", "놀숲"},
        { "3공기", "4공기", "5공기"},
        { "일베", "메갈", "디씨"},
        { "민현", "용호", "다"},
        { "명치", "뚝배기", "김준수"},
        { "롤하고싶다", "집가고싶다", "잠자고싶다"},
        { "전학", "퇴학", "안녕"},
        { "준수", "김준수", "김반준수"},
        { "하스", "능반", "애니"},
        { "몰라", "정말몰라", "혼또니몰라"},
        { "넷마블", "바나나", "우끼끼끼"},
        { "서지원", "김민현", "정의수"},
        { "군대", "순대", "고구려대"},
        { "아재", "아재준수", "준수아재"},
        { "적나라한 빨간색", "새나라의 노란색", "잘모르겠습니다"},
        { "너는?", "나도", "난 인싸"},
        { "여자", "여자", "여자"},
        { "로리", "쇼타", "어린아이"},
        { "기나단조무띠", "기나단조무띠", "기나단조무띠"},
        { "쉬는시간", "급식시간", "방과후"},
    };

    public virtual void Init()
    {
        questionText = GameManager.instance.questionPanel.transform.GetChild(0).GetComponent<Text>();
        questionText.text = question[id];

        for (int i = 0; i < 3; i++)
        {
            answerButton[i] = GameObject.Find("Button" + i.ToString()).GetComponent<Button>();
            answerButton[i].transform.GetChild(0).GetComponent<Text>().text = answer[id,i];
        }
    }
    public virtual void Angry() {
        GameManager.instance.answerPanel.SetActive(false);
        StartCoroutine(angryText());
        GameManager.instance.isPlayerMove = true;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if ((target - transform.position).magnitude < 0.5f)
            TargetSetting();
    }
    public virtual void EnemyMove() { }
    public virtual void TargetSetting()
    {
        float TargetPosX = Random.Range(-50, 50);
        float TargetPosY = Random.Range(10, 45);
        float TargetPosZ = Random.Range(-30, 30);

        target = new Vector3(TargetPosX, TargetPosY, TargetPosZ);
    }
    public virtual void GetInput()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == answerId)
                answerButton[i].onClick.AddListener(delegate ()
                {
                    StartCoroutine(nextText());
                    isInstantiate = true;
                });
            else
                answerButton[i].onClick.AddListener(delegate ()
                {
                    isAngry = true;
                    EnemyMove();
                    GetComponent<Renderer>().material = angryMaterial;
                });
        }
    }

    public virtual IEnumerator nextText() {
        questionText.text = "나 만족했어 나중에 봐 ㅂㅂ";
        yield return new WaitForSeconds(1);
        if (isInstantiate)
        {
            GameManager.instance.NextStage();
            isInstantiate = false;
            Destroy(this.gameObject);
        }
        
    }
    public virtual IEnumerator angryText()
    {
        questionText.text = "나 화났어";
        yield return new WaitForSeconds(1);
        GameManager.instance.questionPanel.SetActive(false);
        yield return null;
    }
}
