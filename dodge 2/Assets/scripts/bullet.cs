using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody bulletRigidbody;
    public float damage = 30f;
    // Start is called before the first frame update
    void Start()
    {
        //������ٵ��� �ӷ� = �Ѿ� ���� ���� * �ӷ�
        speed = 100f;
        bulletRigidbody.velocity = transform.forward * speed;
        //3�� �ڿ� �Ѿ� ������ ������
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<enemy>() == null)
        {
            return;
        }
        other.GetComponent<enemy>().TakeDamage(3);
    }
}
