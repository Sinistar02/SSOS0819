using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    /*
    1.생성할 탄알의 원본 (프리팹)
    2. 탄알을 발사할 목표물의 위치 (플레이어)
    3.탄알 발사하는 시간 간격 (밸런스)
    */
    public GameObject enemyPrefab;
    public float spawnRateMin = 0.5f;//최소생성주기
    public float spawnRateMax = 3f;//최대생성주기
    
    private float spawnRate;//생성주기
    private float timeAfterSpawn;//최근 생성 시점에서 지난 시간
    // Start is called before the first frame update
    void Start()
    {
        //최근 생성 이후 누적 시간 초기화
        timeAfterSpawn = 0f;
        //탄알 생성 간격 설정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;
        //최근 생성 시점에서부터 누적된 시간이 spawnRate보다 크거나 같다면
        if (timeAfterSpawn >= spawnRate)
        {
            //누적 시간 리셋
            timeAfterSpawn = 0f;
            //<핵심> bulletPrefab 복제품을 transform 위치와 회전으로 생성
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            //spawnRate 초기화
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
