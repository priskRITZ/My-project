using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MyCharacterController : MonoBehaviour
{
    // 이동하는 방향에 대한 변수
    private Vector3 MoveDirection;

    // 회전하는 방향에 대한 변수
    private Vector3 RotDirection;

    public float MoveSpeed = 5.0f;
    public float RotSpeed = 180.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveDirection = Vector3.zero;
        RotDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            MoveDirection = transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveDirection = -transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotDirection = -transform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            RotDirection = transform.right;
        }
    }

    private void FixedUpdate()
    {
        if (MoveDirection != Vector3.zero)
        {
            Vector3 nextPosition = Vector3.MoveTowards(transform.position, transform.position + MoveDirection * 1000.0f, Time.fixedDeltaTime * MoveSpeed);

            // fixedDeltaTime == 0.02초 프로젝트 설정
            // 50번 불리니까
            // fixedDeltaTime * MoveSpeed = 1tick당 이동할 거리
            //                거리
            //           ---------------
            //            속력  |  시간

            GetComponent<Rigidbody>().MovePosition(nextPosition);
        }

        if (RotDirection != Vector3.zero)
        {
            Vector3 nextRotaton = Vector3.RotateTowards(transform.forward, RotDirection, Time.fixedDeltaTime * RotSpeed, 0.0f);

            GetComponent<Rigidbody>().MoveRotation(Quaternion.LookRotation(nextRotaton));
        }

        float Speed = 0.0f;

        if (MoveDirection != Vector3.zero)
        {
            Speed = 1.0f;
        }

        GetComponent<Animator>().SetFloat("Speed", Speed);
    }
}