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
        float h = Input.GetAxis("Horizontal"); //키보드 왼쪽 오른쪽 입력받음 왼쪽은 -1 오른쪽은 1
        float v = Input.GetAxis("Vertical"); //키보드 위 아래 입력받음 위는 1 아래쪽은 -1
        Vector3 dir = new Vector3(h, v, 0);//가로 세로 설정
        //transform.position += dir; //해당 좌표로 순간이동되어 엄청 빠름 그래서 벽도 뚫고 지나감
        GetComponent<Rigidbody2D>().velocity //dir의 값만큼 움직이는건데 *5를 해주므로서 이동속도를 늘림 
            = dir * 5;  //물지적인 충돌이기 때문에 만약 1이라는 값으로 이동한다면 0에서1로 천천히 이동함
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WALL")) //만약 벽에 부딪친다면 벽의 색으로 바뀌게 된다.
        {
            GetComponent<SpriteRenderer>().color = collision.collider.GetComponent<SpriteRenderer>().color;
        }
    }

}
