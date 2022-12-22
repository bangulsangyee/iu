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
        //StartCoroutine(ColorBack()); //���Լ��� �ڿ� ������ �Լ� ColorBack�� ����? �ƴ� �ҷ����� �Լ�������� �����ϸ� 
                                     //���ϴ�.
                                     //or
                                     //StartCoroutine("ColorBack");
        StartCoroutine("SoulCreate");


        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //Ű���� ���� ������ �Է¹��� ������ -1 �������� 1
        float v = Input.GetAxis("Vertical"); //Ű���� �� �Ʒ� �Է¹��� ���� 1 �Ʒ����� -1
        Vector3 dir = new Vector3(h, v, 0);//���� ���� ����
        //transform.position += dir; //�ش� ��ǥ�� �����̵��Ǿ� ��û ���� �׷��� ���� �հ� ������
        GetComponent<Rigidbody2D>().velocity //dir�� ����ŭ �����̴°ǵ� *5�� ���ֹǷμ� �̵��ӵ��� �ø� 
            = dir * moveSpeed;  //�������� �浹�̱� ������ ���� 1�̶�� ������ �̵��Ѵٸ� 0����1�� õõ�� �̵���
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WALL")) //���� ���� �ε�ģ�ٸ� ���� ������ �ٲ�� �ȴ�.
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
            //���� �ҿ� ���� ���ٸ� = �ҿ� ����
            if(GetComponent<SpriteRenderer>().color
                == collision.GetComponent<SpriteRenderer>().color)
            {
                Destroy(collision.gameObject);

                moveSpeed += 0.2f;
                score += 1;
                tmp.text = "���� : " + score;
                GetComponent<AudioSource>().Play();
            }

            //���� �ҿ� ���� �ٸ��ٸ� = ��������
            if(GetComponent<SpriteRenderer>().color
                != collision.GetComponent<SpriteRenderer>().color)
            {
                int r = Random.Range(0, 3 + 1);
                float x = Random.Range(-8f, 8f); //x,y�� ���� (�̵������� ���� ����)
                float y = Random.Range(-3f, 4f);
                Vector3 pos = new Vector3(x, y, 0); //(��ġ ���� ���� ������ x,y���� �̿��Ͽ� pos�̶�� ������ ����)
                collision.gameObject.transform.position = pos;

                moveSpeed -= 0.2f;
                score -= 1;
                tmp.text = "���� : " + score;
            }

        }
    }



    IEnumerator ColorBack()
    {
        yield return new WaitForSeconds(3f);

        Color color = new Color32(255, 255, 255, 255); //�ػ�

        GetComponent<SpriteRenderer>().color = color;
        //GetComponent<SpriteRenderer>().color = Color.white; ����Ƽ���� �⺻������ �����ϴ� �� �̷������ �ִ�!

        /*
         Color color = new Color32(255,255,255,255);
        Color color = new Color(1,1,1,1);

        // Color32�� 0~255�� ǥ��
        // Color��   0~1  �� ǥ��
         */
    }

    IEnumerator SoulCreate()
    {
        yield return new WaitForSeconds(3f);
        //�����ڵ�
        //Instantiate(���ӿ�����Ʈ, ��ġ, ȸ��);

        //�����ڵ�
        //Destroy(���ӿ�����Ʈ);
        //gameObject.SetActive(true or false);

        int r = Random.Range(0, 3+1); //������ 0~3������ ���� �׷��� ���� 3���� ������ �ҷ��� 3+1�� ����� ���� ���ϰ���
        //���ڸ��� ���ܵǴ°� (4�ϱ� 3������ �����Եȴ�.)

        float x = Random.Range(-8f, 8f); //x,y�� ���� (�̵������� ���� ����)
        float y = Random.Range(-3f, 4f);
        Vector3 pos = new Vector3(x, y, 0); //(��ġ ���� ���� ������ x,y���� �̿��Ͽ� pos�̶�� ������ ����)

        Instantiate(Soul[r], pos, Quaternion.identity);

        StartCoroutine("SoulCreate");
    }


    /*IEnumerator ColorBack() //�ð� ���� �Լ�
    {
        print("A");
        yield return new WaitForSeconds(2f); //���ʵ��� ��ٸ����� ����
        print("B");
        yield return new WaitForSeconds(2f);
        print("C");
        StartCoroutine(ColorBack());
        //�ڵ��ؼ�
        //A�� ����Ѵ�. 2���� B�� ����Ѵ�. 2����C�� ����ϰ� �ڱ��ڽ��� ����Լ��� �ҷ��ͼ� A���,2���� B���....
        //���ѹݺ�
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
