using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float Speed = 50.0f;
    //public float Speed = 50.0f;
    private Transform myTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveAmount = Speed * Vector3.back * Time.deltaTime;
        myTransform.Translate(moveAmount);

        if (myTransform.position.y <= -60.0f)
        {
            myTransform.position = new Vector3(Random.Range(-60.0f, 60.0f), 60.0f, 0.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            Destroy(this.gameObject);  // Debug 뜸 ->  총알 사라짐.
        }
        if (other.CompareTag("Player"))
            Debug.Log("운석과 충돌하였습니다. 운석을 피하세요.");
    }
}
