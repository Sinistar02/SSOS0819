using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public CharacterController characterController;
    public GameObject bulletPrefab;
    public GameObject cameraPosition;
    public float speed = 8f;
    public bool isZoomin = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }
    private void LateUpdate()
    {
        Camera.main.transform.position = cameraPosition.transform.position;
    }
    void Move()
    {
        float xinput = Input.GetAxis("Horizontal");//A,D키, 방향키 왼쪽, 오른쪽
        Vector3 dir = new Vector3(xinput, 0f, 0f).normalized;//벡터값을 1로 바꾼다
        characterController.Move(dir * speed * Time.deltaTime);
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, Camera.main.transform.position, Camera.main.transform.rotation);
            bullet.transform.LookAt(transform.forward);
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (isZoomin == false)
            {
                Camera.main.fieldOfView = 30f;
                isZoomin = true;
            }
            else
            {
                Camera.main.fieldOfView = 60f;
                isZoomin = false;
            }
        }
    }
}
