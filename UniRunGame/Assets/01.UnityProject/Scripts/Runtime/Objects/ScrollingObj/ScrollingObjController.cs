using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string prefabName = default;
    public int scrollingObjCount = default;
    public float scrollingSpeed = default;
    protected GameObject objPrefab = default;
    protected Vector2 objPrefabSize = default;
    protected List<GameObject> scrollingPool = default;
    protected float prefabYPos = default;

    public virtual void Start()
    {
        objPrefab = gameObject.FindChildObj(prefabName); // 내가 원하는 자식 오브젝트 찾아서
        scrollingPool = new List<GameObject>();
        GFunc.Assert(objPrefab != null || objPrefab != default);

        objPrefabSize = objPrefab.GetRectSizeDelta(); // 프리팹 사이즈 가져와
        prefabYPos = objPrefab.transform.localPosition.y;
        // { 스크롤링 풀을 생성해서 주어진 수만큼 초기화
        GameObject tempObj = default;
        if (scrollingPool.Count <= 0) // 스크롤링 풀에 아무것도 없다면
        {
            for (int i = 0; i < scrollingObjCount; i++) // 카운트만큼 생성하고
            {
                tempObj = Instantiate(objPrefab,
                    objPrefab.transform.position,
                    objPrefab.transform.rotation, transform);

                scrollingPool.Add(tempObj); // 퓰에 집어넣는다.
                tempObj = default;
            }       // loop: 스크롤링 오브젝트를 주어진 수만큼 초기화 하는 루프
        }       // if: scrolling pool을 초기화 한다.

        objPrefab.SetActive(false);
        InitObjsPosition();
        // } 스크롤링 풀을 생성해서 주어진 수만큼 초기화
    }       // Start()

    // Update is called once per frame
    public virtual void Update()
    {
        if (scrollingPool == default || scrollingPool.Count <= 0)
        {
            return;
        }   // if : 스크롤링 할 오브젝트가 존재하지 않는 경우 끝낸다.

        if (GameManager.instance.isGameOver == false)
        {

            // { 배경에 움직임을 주는 로직      
            // 스크롤링 할 오브젝트가 존재하는 경우
            for (int i = 0; i < scrollingObjCount; i++)
            {
                scrollingPool[i].AddLocalPos(scrollingSpeed * Time.deltaTime * (-1), 0f, 0f);
            }   // loop : 배경이 왼쪽으로 움직이도록 하는 루프
            // 스크롤링 풀의 첫번쨰 오브젝트를 마지막으로 리포지셔닝 하는 로직
           RepositionFirstObj();
            // } 배경에 움직임을 주는 로직
        }   // if : 게임이 진행중인 경우
    }   // Update()

    //! 생성한 오브젝트의 위치를 설정하는 함수
    protected virtual void InitObjsPosition()
    {
        /* Do something */
    }        // InitObjsPosition
    

    //! 스크롤링 풀의 첫번쨰 오브젝트를 마지막으로 리포지셔닝 하는 함수
    protected virtual void RepositionFirstObj()
    {
        /* Do something */
    }           // RepositionFirstObj
}
/*
캐싱 : 메모리에다 저장하는 작업 ex) 변수 -> 저장
*/