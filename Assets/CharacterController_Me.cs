using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_Me : MonoBehaviour
{
    public float speed = 20;
    public float rotSpeed;
    public float jumpPower;

    bool isGrounded = true;

    // ��ǲ�� Update���� �ޱ� ����
    // direction�� rotDirection�� ��� ������ �ΰ�
    Vector3 direction = Vector3.zero;
    Vector3 rotDirection = Vector3.zero;

    public GameObject CharacterObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        // �� ������Ʈ ���� direction, rotDirection�� �ʱ�ȭ ���༭
        // �� ���� ��ǲ����ǵ��� �Ѵ�.
        direction = Vector3.zero;
        rotDirection = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction += CharacterObject.transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += -CharacterObject.transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotDirection += -CharacterObject.transform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rotDirection += CharacterObject.transform.right;
        }

        // ������ ���̸� ����ȭ �Ͽ� ���̰� 1�� ���͸� ����� ����
        direction.Normalize();
        rotDirection.Normalize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �̵� ���� 
        // current, target���� speed * Time.fixedDeltaTime��ŭ �̵��� ������ ��ġ�� ��ȯ�Ѵ�.
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, transform.position + direction * 1000, speed * Time.fixedDeltaTime);

        // nextPosition���� �����̵��Ѵ�.
        GetComponent<Rigidbody>().MovePosition(nextPosition);
        // �̵� ���� ��

        // ȸ�� ����
        if (rotDirection.sqrMagnitude > 0.001f)
        {
            // newRot�� ����Ѵ�.
            // trnasform.rotation�� ���� ���� ���� �ִ� �����̴�.
            // Quaternion.LookRotation(direction) // ���� �ٶ� �����̴�.
            // Quaternion�� RotateToward�� current -> new �� ȸ���� ���� ���ϴµ�
            // �� ���� Time.fixedDeltaTime * rotSpeed ���̴�.
            Quaternion newRot = Quaternion.RotateTowards(CharacterObject.transform.rotation, Quaternion.LookRotation(rotDirection), Time.fixedDeltaTime * rotSpeed);

            CharacterObject.transform.rotation = newRot;
        }
        // ȸ�� ���� ��


        // ProjectSetting -> Time -> fixed Timestep 0.02
        // Time.fixedDeltaTime == 0.02
    }

    // �� ������Ʈ�� gameObject�� �ø����� �ٸ� ��ü�� �浹�� collision�� �浹 ������ �Ͼ
    void OnCollisionEnter(Collision collision)
    {
        // collision.tag ? == ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);

        if (other.gameObject.CompareTag("Jewelry"))
        {
            other.gameObject.GetComponent<ScoreEffectScript>().OnHit();
        }
    }
}