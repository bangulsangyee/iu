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
        //float h = Input.GetAxis("Horizontal"); //키보드 왼쪽 오른쪽 입력받음 왼쪽은 -1 오른쪽은 1
        //print(h);
        float v = Input.GetAxis("Vertical"); //키보드 위 아래 입력받음 위는 1 아래쪽은 -1
        print(v);
    }
}
