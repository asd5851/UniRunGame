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
        objPrefab = gameObject.FindChildObj(prefabName); // ���� ���ϴ� �ڽ� ������Ʈ ã�Ƽ�
        scrollingPool = new List<GameObject>();
        GFunc.Assert(objPrefab != null || objPrefab != default);

        objPrefabSize = objPrefab.GetRectSizeDelta(); // ������ ������ ������
        prefabYPos = objPrefab.transform.localPosition.y;
        // { ��ũ�Ѹ� Ǯ�� �����ؼ� �־��� ����ŭ �ʱ�ȭ
        GameObject tempObj = default;
        if (scrollingPool.Count <= 0) // ��ũ�Ѹ� Ǯ�� �ƹ��͵� ���ٸ�
        {
            for (int i = 0; i < scrollingObjCount; i++) // ī��Ʈ��ŭ �����ϰ�
            {
                tempObj = Instantiate(objPrefab,
                    objPrefab.transform.position,
                    objPrefab.transform.rotation, transform);

                scrollingPool.Add(tempObj); // ǽ�� ����ִ´�.
                tempObj = default;
            }       // loop: ��ũ�Ѹ� ������Ʈ�� �־��� ����ŭ �ʱ�ȭ �ϴ� ����
        }       // if: scrolling pool�� �ʱ�ȭ �Ѵ�.

        objPrefab.SetActive(false);
        InitObjsPosition();
        // } ��ũ�Ѹ� Ǯ�� �����ؼ� �־��� ����ŭ �ʱ�ȭ
    }       // Start()

    // Update is called once per frame
    public virtual void Update()
    {
        if (scrollingPool == default || scrollingPool.Count <= 0)
        {
            return;
        }   // if : ��ũ�Ѹ� �� ������Ʈ�� �������� �ʴ� ��� ������.

        if (GameManager.instance.isGameOver == false)
        {

            // { ��濡 �������� �ִ� ����      
            // ��ũ�Ѹ� �� ������Ʈ�� �����ϴ� ���
            for (int i = 0; i < scrollingObjCount; i++)
            {
                scrollingPool[i].AddLocalPos(scrollingSpeed * Time.deltaTime * (-1), 0f, 0f);
            }   // loop : ����� �������� �����̵��� �ϴ� ����
            // ��ũ�Ѹ� Ǯ�� ù���� ������Ʈ�� ���������� �������Ŵ� �ϴ� ����
           RepositionFirstObj();
            // } ��濡 �������� �ִ� ����
        }   // if : ������ �������� ���
    }   // Update()

    //! ������ ������Ʈ�� ��ġ�� �����ϴ� �Լ�
    protected virtual void InitObjsPosition()
    {
        /* Do something */
    }        // InitObjsPosition
    

    //! ��ũ�Ѹ� Ǯ�� ù���� ������Ʈ�� ���������� �������Ŵ� �ϴ� �Լ�
    protected virtual void RepositionFirstObj()
    {
        /* Do something */
    }           // RepositionFirstObj
}
/*
ĳ�� : �޸𸮿��� �����ϴ� �۾� ex) ���� -> ����
*/