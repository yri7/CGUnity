using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    public class CabinetMain : MonoBehaviour
{
    private GameObject target;
    public static int sceneNum = 0;
    public static int clickedObject = 0;

    // 전체 조각상 개수
    public static int TotalObjectNum = 16;

    // 임시 변수(게임시작 스크립트에서 받을 예정)
    public static int[] successList = new int[TotalObjectNum];
    // Start is called before the first frame update
    void Start()
    {
        clickedObject = 0;
        for(int k = 0; k<TotalObjectNum; k++)
        {
            successList[k] = 1;
        }

        for (int i = 0; i < TotalObjectNum; i++)
        {
            if (successList[i] == 0)  //완성 이전
            {
                //보이지 않음
                ObjectNum(i + 1).SetActive(false);
            }
            else if (successList[i] == 1)    //완성 직후
            {
                //보임. new이펙트 출력(추가필요)
                //클릭해야 new이펙트가 없어지게끔 할 경우
                //update의 GetClicked시 success포인트 증가로 변경
                ObjectNum(i + 1).SetActive(true);
                successList[i] = 2;
            }
            else if (successList[i] == 2)
            {
                //new이펙트 제거(추가필요)
                ObjectNum(i + 1).SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();
            if (target.Equals(GameObject.Find("apple_1")))  //선택된 물체 확인
            {
                //클릭 확인, 조각상별 고유번호 부여
                clickedObject = 1;
            }
            else if (target.Equals(GameObject.Find("apple_2")))
            {
                clickedObject = 2;
            }
            else if (target.Equals(GameObject.Find("cherries_1")))
            {
                clickedObject = 3;
            }
            else if (target.Equals(GameObject.Find("cherries_2")))
            {
                clickedObject = 4;
            }
            else if (target.Equals(GameObject.Find("shark_1")))
            {
                clickedObject = 5;
            }
            else if (target.Equals(GameObject.Find("shark_2")))
            {
                clickedObject = 6;
            }
            else if (target.Equals(GameObject.Find("Cube (6)")))
            {
                clickedObject = 7;
            }
            else if (target.Equals(GameObject.Find("Cube (7)")))
            {
                clickedObject = 8;
            }
            else if (target.Equals(GameObject.Find("queen_1")))
            {
                clickedObject = 9;
            }
            else if (target.Equals(GameObject.Find("queen_2")))
            {
                clickedObject = 10;
            }
            else if (target.Equals(GameObject.Find("head_1")))
            {
                clickedObject = 11;
            }
            else if (target.Equals(GameObject.Find("head_2")))
            {
                clickedObject = 12;
            }
            else if (target.Equals(GameObject.Find("horse_1")))
            {
                clickedObject = 13;
            }
            else if (target.Equals(GameObject.Find("horse_2")))
            {
                clickedObject = 14;
            }
            else if (target.Equals(GameObject.Find("gun_1")))
            {
                clickedObject = 15;
            }
            else if (target.Equals(GameObject.Find("gun_2")))
            {
                clickedObject = 16;
            }
        }
        if (clickedObject > 0)
        {
            //선택된 조각상에 맞는 상세보기 scene으로 이동
            sceneNum++;
            SceneManager.LoadScene(sceneNum, LoadSceneMode.Single);
        }
    }
    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 
        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인
        {
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }
        return target;
    }
    public GameObject ObjectNum(int n)
    {
        switch (n)
        {
            case 1:
                return GameObject.Find("Cabinet").transform.Find("apple_1").gameObject;
            case 2:
                return GameObject.Find("Cabinet").transform.Find("apple_2").gameObject;
            case 3:
                return GameObject.Find("Cabinet").transform.Find("cherries_1").gameObject;
            case 4:
                return GameObject.Find("Cabinet").transform.Find("cherries_2").gameObject;
            case 5:
                return GameObject.Find("Cabinet").transform.Find("shark_1").gameObject;
            case 6:
                return GameObject.Find("Cabinet").transform.Find("shark_2").gameObject;
            case 7:
                return GameObject.Find("Cabinet").transform.Find("Cube (6)").gameObject;
            case 8:
                return GameObject.Find("Cabinet").transform.Find("Cube (7)").gameObject;
            case 9:
                return GameObject.Find("Cabinet").transform.Find("queen_1").gameObject;
            case 10:
                return GameObject.Find("Cabinet").transform.Find("queen_2").gameObject;
            case 11:
                return GameObject.Find("Cabinet").transform.Find("head_1").gameObject;
            case 12:
                return GameObject.Find("Cabinet").transform.Find("head_2").gameObject;
            case 13:
                return GameObject.Find("Cabinet").transform.Find("horse_1").gameObject;
            case 14:
                return GameObject.Find("Cabinet").transform.Find("horse_2").gameObject;
            case 15:
                return GameObject.Find("Cabinet").transform.Find("gun_1").gameObject;
            case 16:
                return GameObject.Find("Cabinet").transform.Find("gun_2").gameObject;
            default:
                return null;
        }
    }
}
