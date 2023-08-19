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
        //리지드바디의 속력 = 총알 앞쪽 방향 * 속력
        speed = 100f;
        bulletRigidbody.velocity = transform.forward * speed;
        //3초 뒤에 총알 스스로 삭제함
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
