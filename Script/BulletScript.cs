using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
     
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 1초에 총알 스피트만큼 날아감
        gameObject.transform.position += gameObject.transform.up * Time.deltaTime * speed;
        //up 위쪽 방향으로 이동(회전해도 앞 유지)
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            //Debug.Log("Target");
            Debug.Log(other.transform.name + "에게 데미지" + damage + "을 입혔습니다.");
            Destroy(this.gameObject);  // Debug 뜸 ->  총알 사라짐.
            Destroy(other);
        }
    }
}
