using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public GameObject[] Soul;

    float moveSpeed;

    int score;

    public TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3f;
        score = 0;
        //StartCoroutine(ColorBack()); //이함수는 뒤에 설정한 함수 ColorBack을 시작? 아니 불러오는 함수정도라고 생각하면 
                                     //편하다.
                                     //or
                                     //StartCoroutine("ColorBack");
        StartCoroutine("SoulCreate");


        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //키보드 왼쪽 오른쪽 입력받음 왼쪽은 -1 오른쪽은 1
        float v = Input.GetAxis("Vertical"); //키보드 위 아래 입력받음 위는 1 아래쪽은 -1
        Vector3 dir = new Vector3(h, v, 0);//가로 세로 설정
        //transform.position += dir; //해당 좌표로 순간이동되어 엄청 빠름 그래서 벽도 뚫고 지나감
        GetComponent<Rigidbody2D>().velocity //dir의 값만큼 움직이는건데 *5를 해주므로서 이동속도를 늘림 
            = dir * moveSpeed;  //물지적인 충돌이기 때문에 만약 1이라는 값으로 이동한다면 0에서1로 천천히 이동함
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WALL")) //만약 벽에 부딪친다면 벽의 색으로 바뀌게 된다.
        {
            GetComponent<SpriteRenderer>().color = collision.collider.GetComponent<SpriteRenderer>().color;

            StopCoroutine("ColorBack");
            StartCoroutine("ColorBack");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SOUL"))
        {
            //나와 소울 색이 같다면 = 소울 없앰
            if(GetComponent<SpriteRenderer>().color
                == collision.GetComponent<SpriteRenderer>().color)
            {
                Destroy(collision.gameObject);

                moveSpeed += 0.2f;
                score += 1;
                tmp.text = "점수 : " + score;
                GetComponent<AudioSource>().Play();
            }

            //나와 소울 색이 다르다면 = 도망가게
            if(GetComponent<SpriteRenderer>().color
                != collision.GetComponent<SpriteRenderer>().color)
            {
                int r = Random.Range(0, 3 + 1);
                float x = Random.Range(-8f, 8f); //x,y값 설정 (이동가능한 범위 설정)
                float y = Random.Range(-3f, 4f);
                Vector3 pos = new Vector3(x, y, 0); //(위치 설정 위에 설정한 x,y값을 이용하여 pos이라는 변수를 설정)
                collision.gameObject.transform.position = pos;

                moveSpeed -= 0.2f;
                score -= 1;
                tmp.text = "점수 : " + score;
            }

        }
    }



    IEnumerator ColorBack()
    {
        yield return new WaitForSeconds(3f);

        Color color = new Color32(255, 255, 255, 255); //휜색

        GetComponent<SpriteRenderer>().color = color;
        //GetComponent<SpriteRenderer>().color = Color.white; 유니티에서 기본적으로 지원하는 것 이런방법도 있다!

        /*
         Color color = new Color32(255,255,255,255);
        Color color = new Color(1,1,1,1);

        // Color32는 0~255로 표시
        // Color는   0~1  로 표시
         */
    }

    IEnumerator SoulCreate()
    {
        yield return new WaitForSeconds(3f);
        //생성코드
        //Instantiate(게임오브젝트, 위치, 회전);

        //삭제코드
        //Destroy(게임오브젝트);
        //gameObject.SetActive(true or false);

        int r = Random.Range(0, 3+1); //랜덤은 0~3까지만 뱉음 그래서 보통 3까지 나오게 할려면 3+1를 사용해 보기 편하게함
        //끝자리가 제외되는것 (4니깐 3까지만 나오게된다.)

        float x = Random.Range(-8f, 8f); //x,y값 설정 (이동가능한 범위 설정)
        float y = Random.Range(-3f, 4f);
        Vector3 pos = new Vector3(x, y, 0); //(위치 설정 위에 설정한 x,y값을 이용하여 pos이라는 변수를 설정)

        Instantiate(Soul[r], pos, Quaternion.identity);

        StartCoroutine("SoulCreate");
    }


    /*IEnumerator ColorBack() //시간 지연 함수
    {
        print("A");
        yield return new WaitForSeconds(2f); //몇초동안 기다릴건지 설정
        print("B");
        yield return new WaitForSeconds(2f);
        print("C");
        StartCoroutine(ColorBack());
        //코드해석
        //A를 출력한다. 2초후 B를 출력한다. 2초후C를 출력하고 자긴자신을 재귀함수로 불러와서 A출력,2초후 B출력....
        //무한반복
    }
    */

    public void Left()
    {
        transform.position += new Vector3(-1, 0, 0) * moveSpeed * 0.15f;
    }
    public void Right()
    {
        transform.position += new Vector3(1, 0, 0) * moveSpeed * 0.15f;
    }
    public void Up()
    {
        transform.position += new Vector3(0, 1, 0) * moveSpeed * 0.15f;
    }
    public void Down()
    {
        transform.position += new Vector3(0, -1, 0) * moveSpeed * 0.15f;
    }

}
