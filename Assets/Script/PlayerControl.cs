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
        //float h = Input.GetAxis("Horizontal"); //Ű���� ���� ������ �Է¹��� ������ -1 �������� 1
        //print(h);
        float v = Input.GetAxis("Vertical"); //Ű���� �� �Ʒ� �Է¹��� ���� 1 �Ʒ����� -1
        print(v);
    }
}
