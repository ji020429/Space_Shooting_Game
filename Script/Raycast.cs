using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    //트렌스폼을 담을 변수
    public Transform m_tr;

    //레이 길이를 지정할 변수
    public float distance = 15.0f;

    //충돌 정보를 가져올 레이케스트 히트
    public RaycastHit hit;

    //레이어 마스크를 지정할 변수
    public LayerMask m_layerMask = -1;

    //충돌 정보를 여러개 담을 레이케스트 히트 배열
    public RaycastHit[] hits;

    // Start is called before the first frame update
    void Start()
    {
        //물체의 트렌스폼을 받아온다
        m_tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //레이 셋팅
        Ray ray = new Ray();

        //시작지점 셋팅
        ray.origin = m_tr.position;

        //방향설정
        ray.direction = m_tr.forward;


        //=============하나만 검출하는 레이===============
        ////사용 방법 4가지

        //// 1. 레이에 검출되는 것이 있다면(충돌이 되었다면) "hit!"
        //if (Physics.Raycast(ray)) // bool 값으로 반환
        //{
        //    print("hit!"); // 충돌되는 물체가 무언가 있음.
        //}

        //// 2. 레이에 검출되는 것의 이름을 출력
        //if (Physics.Raycast(ray, out hit))
        //{
        //    print(hit.collider.name + "와 레이가 충돌");
        //}

        //// 3. 레이에 검출되는 것의 이름을 출력하는데 거리가 정해짐
        //if (Physics.Raycast(ray, out hit, distance))
        //{
        //    print(hit.collider.name + "와 레이가 충돌");
        //}

        //// 4. 지정된 레이어마스크만 레이에 검출되고 검출되는 것의 이름을 출력하는데 거리가 정해짐
        ////Ratcast를 넣어둔 물체의 Inspector창에 layerMask가 추가되어 레이어를 고를 수 있음
        //if (Physics.Raycast(ray, out hit, distance, m_layerMask))
        //{
        //    print(hit.collider.name + "와 레이가 충돌");
        //}


        //=============여러물체를 검출하는 레이===============
        //RaycastAll는 RaycastHit를 반환
        hits = Physics.RaycastAll(ray, distance, m_layerMask);


        //hits의 길이를 확인하고 사용
        if (hits.Length > 0)
        {
            //배열로 담아온 정보를 for문으로 각 오브젝트들의 이름을 출력
            for (int i = 0; i < hits.Length; i++)
            {
                print(hits[i].collider.gameObject.name + " " + i);
            }
        }
        OnDrawRayLine();
    }



    public void OnDrawRayLine()//레이 시각화(충돌시에 red, 기본시에 white)(게임화면에는 안잡힘)
    {
        if (hit.collider != null || hits.Length > 0)
        {
            Debug.DrawLine(m_tr.position, m_tr.position + m_tr.forward * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawLine(m_tr.position, m_tr.position + m_tr.forward * this.distance, Color.white);
        }
    }

}
