using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    /*
    1.������ ź���� ���� (������)
    2. ź���� �߻��� ��ǥ���� ��ġ (�÷��̾�)
    3.ź�� �߻��ϴ� �ð� ���� (�뷱��)
    */
    public GameObject enemyPrefab;
    public float spawnRateMin = 0.5f;//�ּһ����ֱ�
    public float spawnRateMax = 3f;//�ִ�����ֱ�
    
    private float spawnRate;//�����ֱ�
    private float timeAfterSpawn;//�ֱ� ���� �������� ���� �ð�
    // Start is called before the first frame update
    void Start()
    {
        //�ֱ� ���� ���� ���� �ð� �ʱ�ȭ
        timeAfterSpawn = 0f;
        //ź�� ���� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;
        //�ֱ� ���� ������������ ������ �ð��� spawnRate���� ũ�ų� ���ٸ�
        if (timeAfterSpawn >= spawnRate)
        {
            //���� �ð� ����
            timeAfterSpawn = 0f;
            //<�ٽ�> bulletPrefab ����ǰ�� transform ��ġ�� ȸ������ ����
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            //spawnRate �ʱ�ȭ
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
