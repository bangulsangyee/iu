using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //Ű���� ���� ������ �Է¹��� ������ -1 �������� 1
        float v = Input.GetAxis("Vertical"); //Ű���� �� �Ʒ� �Է¹��� ���� 1 �Ʒ����� -1
        Vector3 dir = new Vector3(h, v, 0);//���� ���� ����
        //transform.position += dir; //�ش� ��ǥ�� �����̵��Ǿ� ��û ���� �׷��� ���� �հ� ������
        GetComponent<Rigidbody2D>().velocity //dir�� ����ŭ �����̴°ǵ� *5�� ���ֹǷμ� �̵��ӵ��� �ø� 
            = dir * 5;  //�������� �浹�̱� ������ ���� 1�̶�� ������ �̵��Ѵٸ� 0����1�� õõ�� �̵���
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WALL")) //���� ���� �ε�ģ�ٸ� ���� ������ �ٲ�� �ȴ�.
        {
            GetComponent<SpriteRenderer>().color = collision.collider.GetComponent<SpriteRenderer>().color;
        }
    }

}
