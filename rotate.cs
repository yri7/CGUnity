using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField]
    private GameObject target = null;       // 타겟이 될 게임오브젝트
    private Vector3 point = Vector3.zero;   // 타겟의 위치(바라볼 위치)

    private float rotationX = 0.0f;         // X축 회전값
    private float rotationY = 0.0f;         // Y축 회전값
    private float speed = 500.0f;           // 회전속도


    void Start()
    {
        // 바라볼 위치 얻기
        point = target.transform.position;
    }

    void Update()
    {
        // 마우스가 눌러지면,
        if (Input.GetMouseButton(0))
        {
            // 마우스 변화량을 얻고, 그 값에 델타타임과 속도를 곱해서 회전값 구하기
            rotationX = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            rotationY = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;

            // 각 축으로 회전
            transform.RotateAround(point, Vector3.right, -rotationY);
            transform.RotateAround(point, Vector3.up, rotationX);

            // 회전후 타겟 바라보기
            transform.LookAt(point);
        }
    }
}
