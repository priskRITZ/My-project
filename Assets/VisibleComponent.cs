using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleComponent : MonoBehaviour
{
    // �����ڶ� ����
    // Ŭ������ �ν��Ͻ� ȭ �ɶ� �ʱ⿡ ���� ���� �Ҹ��� �Լ����� ��Ȱ�� �ϴµ�
    // ����Ƽ������ �� �����ڸ� ���� �ȵ˴ϴ�.
    void Awake()
    {
    }

    // Start is called before the first frame update

    // ������Ʈ�� Loop �Ź� ƽ ���� ���µ�
    // ó�� Update�Լ��� �Ҹ��� ������ �Ҹ��� �Լ�
    void Start()
    {
    }

    // ������Ʈ�� ������ �� ȣ��ȴ�. �翬�� �����ÿ� ������Ʈ�� �����ִٸ�
    // �� �Լ��� ȣ���� �ȴ�.
    void OnEnable()
    {

    }

    // ������Ʈ�� ������ �� ȣ�� �ȴ�.
    void OnDisable()
    {

    }

    // ������Ʈ�� �ı��� �� ȣ��ȴ�.
    void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }

    // �� ƽ���� ������ �����ϴ� �Լ��̴�.
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {

        }


    }

    // Update���� �������� ���� ������Ʈ�� �ϰ� ������ ���°̴ϴ�.
    void LateUpdate()
    {

    }

    // ���� time setting�� ���� ���õ� ������ �Ҹ���.
    void FixedUpdate()
    {

    }
}