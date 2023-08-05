using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipScript : MonoBehaviour
{
    // 특정 물체만 맞게 하기
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private float moveSpeed = 10.0f;
    private float v;
    private float h;

    public GameObject _bullet = null;
    public Transform _BulletPosition;

    private float _currentTime;


    void Start()
    {
        _currentTime = Time.time;
    }

    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        gameObject.transform.position += new Vector3(h, 0, v) * Time.deltaTime * moveSpeed; //프레임을 평균으로

        if (Input.GetKey(KeyCode.Space))  //GetKey(눌렸을 때 계속 호출) , down(눌렸을 때 호출), up (떼었을 때 호출)
            Fire();

        gameObject.transform.position += new Vector3(h, 0, v) * Time.deltaTime * moveSpeed;

        // 충돌한 것의 정보를 저장할 변수
        RaycastHit hitInfo;

        // 레이저를 쐈을 때 충돌했는지 여부 . Raycast
        // (자기 위치, 정면으로 쏠 때, 충돌한 것의 정보, 사정거리, 특정layerMaskr만 충돌하게(충돌하면 hitInfo에 넣음))
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 10f, layerMask))
        {
            //Debug.Log(hitInfo.transform.name);  // 충돌한 것 이름 띄우기
        }
    }

    public void set_moveSpeed(float value)
    {
        moveSpeed = value;
    }
    public void Fire()
    {
        if (Time.time - _currentTime > 0.1f)
        {
            _currentTime = Time.time; //마지막으로 스페이스바 누른 시간 _currentTime에 저장
            Instantiate(_bullet, _BulletPosition.position, _BulletPosition.rotation); 
            //오브젝트(객체) 생성, (생성하고자 하는 것, 생성하고자 하는 위치, 생성할 때 회전값), .rotation 허수 회전축은 4개
        }
    }
}

