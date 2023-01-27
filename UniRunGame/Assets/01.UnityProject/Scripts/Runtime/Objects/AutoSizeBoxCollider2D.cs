using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSizeBoxCollider2D : MonoBehaviour
{
    public bool isUseParentSize = false;
    void Start()
    {
        Vector2 objSize_ = default;

        BoxCollider2D boxCollider_ = 
            gameObject.GetComponentMust<BoxCollider2D>();
        RectTransform parentRectTransform_ = transform.parent. // 부모 트랜스폼
            gameObject.GetComponentMust<RectTransform>();
        RectTransform rectTransform_ = // 자기 트랜스폼
            gameObject.GetComponentMust<RectTransform>();
        
        if(isUseParentSize)
        {
            objSize_.x = parentRectTransform_.sizeDelta.x;
            objSize_.y = rectTransform_.sizeDelta.y;
        }
        else
        {
            objSize_.x = rectTransform_.sizeDelta.x;
            objSize_.y = rectTransform_.sizeDelta.y;
        }
        boxCollider_.size = objSize_;

    }       // Start()
}
