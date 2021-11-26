using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectDisplay : MonoBehaviour
{
    private GameObject target;


    // CabinetMain의 함수 호출용
    //private CabinetMain CabinetFunc;


    // Start is called before the first frame update
    void Start()
    {
        // 외부 스크립트 함수 불러오기 코드였는데 안돌아감
        /*
        CabinetFunc = GameObject.Find("shelf").GetComponent<CabinetMain>();
        for(int i = 0; i < CabinetMain.TotalObjectNum; i++)
        {
            CabinetFunc.ObjectNum(i).SetActive(false);
        }
        CabinetFunc.ObjectNum(CabinetMain.clickedObject).SetActive(true);
        */

        GameObject.Find("Stand").transform.Find("apple_1").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("apple_2").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("cherries_1").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("cherries_2").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("shark_1").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("shark_2").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("Cube (6)").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("Cube (7)").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("queen_1").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("queen_2").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("head_1").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("head_2").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("horse_1").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("horse_2").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("gun_1").gameObject.SetActive(false);
        GameObject.Find("Stand").transform.Find("gun_2").gameObject.SetActive(false);
        
        switch (CabinetMain.clickedObject)
        {
            case 1:
                GameObject.Find("Stand").transform.Find("apple_1").gameObject.SetActive(true);
                break;
            case 2:
                GameObject.Find("Stand").transform.Find("apple_2").gameObject.SetActive(true);
                break;
            case 3:
                GameObject.Find("Stand").transform.Find("cherries_1").gameObject.SetActive(true);
                break;
            case 4:
                GameObject.Find("Stand").transform.Find("cherries_2").gameObject.SetActive(true);
                break;
            case 5:
                GameObject.Find("Stand").transform.Find("shark_1").gameObject.SetActive(true);
                break;
            case 6:
                GameObject.Find("Stand").transform.Find("shark_2").gameObject.SetActive(true);
                break;
            case 7:
                GameObject.Find("Stand").transform.Find("Cube (6)").gameObject.SetActive(true);
                break;
            case 8:
                GameObject.Find("Stand").transform.Find("Cube (7)").gameObject.SetActive(true);
                break;
            case 9:
                GameObject.Find("Stand").transform.Find("queen_1").gameObject.SetActive(true);
                break;
            case 10:
                GameObject.Find("Stand").transform.Find("queen_2").gameObject.SetActive(true);
                break;
            case 11:
                GameObject.Find("Stand").transform.Find("head_1").gameObject.SetActive(true);
                break;
            case 12:
                GameObject.Find("Stand").transform.Find("head_2").gameObject.SetActive(true);
                break;
            case 13:
                GameObject.Find("Stand").transform.Find("horse_1").gameObject.SetActive(true);
                break;
            case 14:
                GameObject.Find("Stand").transform.Find("horse_2").gameObject.SetActive(true);
                break;
            case 15:
                GameObject.Find("Stand").transform.Find("gun_1").gameObject.SetActive(true);
                break;
            case 16:
                GameObject.Find("Stand").transform.Find("gun_2").gameObject.SetActive(true);
                break;
            default: CabinetMain.sceneNum = 0;
                     SceneManager.LoadScene(CabinetMain.sceneNum, LoadSceneMode.Single);
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();
            if (target.Equals(GameObject.Find("ReturnButton")))  //선택된 물체 확인
            {
                // 첫 화면으로 돌아가기
                // 색이...왜...이상해질까요?
                CabinetMain.sceneNum = 0;
                SceneManager.LoadScene(CabinetMain.sceneNum, LoadSceneMode.Single);
            }
        }
    }
    // 임시 닫기버튼 생성
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
}
