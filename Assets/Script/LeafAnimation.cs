using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LeafAnimation : MonoBehaviour
{
    public GameObject leaf;
    public float animationSpeed;

    public bool isVisible = true;

    public Vector3 scaleDown;
    public Vector3 scaleOrig;
    
    public Vector3 moveUp;
    public Vector3 moveDown;
    public Vector3 moveOrig;

    public Vector3 rotateSide;
    public Vector3 rotateOrig;

    public float yRotation;
    public Vector3 currentPosition;

    void Update()
    {
        currentPosition = leaf.transform.position;

        yRotation = leaf.transform.eulerAngles.y;
    }

    public void Scale()
    {
        Image mat;
        mat = leaf.GetComponent<Image>();
        
        CheckScaleAndZoom();

        if(isVisible)
        {
            leaf.transform.DOScale(scaleDown, animationSpeed);
            mat.DOFade(0,0.2f);
            isVisible = false;
        }
        else
        {
            mat.DOFade(0,0f);
            
            mat.DOFade(1,0.5f);
            leaf.transform.DOScale(scaleOrig, animationSpeed);
            isVisible = true;
        }
        
    }

    public void Zoom()
    {
        Image mat;
        mat = leaf.GetComponent<Image>();
        
        CheckScaleAndZoom();

        if(isVisible)
        {
            leaf.transform.DOScale(scaleDown, animationSpeed);
            isVisible = false;
        }
        else
        {
            mat.DOFade(1,0f);

            leaf.transform.DOScale(scaleOrig, animationSpeed);
            isVisible = true;
        }
        
    }

    public void FadeUp()
    {
        Image mat;
        mat = leaf.GetComponent<Image>();

        CheckFadeUpAndDown();

        if(leaf.transform.localPosition != moveDown && isVisible == false)
        {
            leaf.transform.localPosition = moveDown;
        }
        
        if(isVisible)
        {
            leaf.transform.DOLocalMove(moveDown, animationSpeed);
            mat.DOFade(0,0.5f);
            isVisible = false;
        }
        else
        {
            mat.DOFade(0,0f);
            
            mat.DOFade(1,0.5f);
            leaf.transform.DOLocalMove(moveOrig, animationSpeed);
            isVisible = true;
        }
        
    }

     public void FadeDown()
    {
        Image mat;
        mat = leaf.GetComponent<Image>();

        CheckFadeUpAndDown();

        if(leaf.transform.localPosition != moveUp && isVisible == false)
        {
            leaf.transform.localPosition = moveUp;
        }

        if(isVisible)
        {
            leaf.transform.DOLocalMove(moveUp, animationSpeed);
            mat.DOFade(0,0.5f);
            isVisible = false;
        }
        else
        {
            mat.DOFade(0,0f);

            mat.DOFade(1,0.5f);
            leaf.transform.DOLocalMove(moveOrig, animationSpeed);
            isVisible = true;
        }
    }

    public void Shake()
    {
        Image mat;
        mat = leaf.GetComponent<Image>();

        CheckRotation();
        CheckShakeAndRotate();

        if(isVisible)
        {
            leaf.transform.DOShakePosition(1, 10, 20);
            mat.DOFade(0,0.5f);
            isVisible = false;
        }
        else
        {
            mat.DOFade(0,0f);

            mat.DOFade(1,0.2f);
            leaf.transform.DOShakePosition(1, 10, 20);
            isVisible = true;
        }
        
    }

    public void Rotate()
    {
        Image mat;
        mat = leaf.GetComponent<Image>();

        CheckShakeAndRotate();

        if(yRotation != 90f && isVisible == false)
        {
            leaf.transform.Rotate(0f,90f,0f);
        }

        if(isVisible)
        {
            leaf.transform.DOLocalRotate(rotateSide, animationSpeed);
            isVisible = false;
        }
        else
        {
            mat.DOFade(1,0f);

            leaf.transform.DOLocalRotate(rotateOrig, animationSpeed);
            isVisible = true;
        }
    }

    public void CheckRotation()
    {
        if(yRotation != 0f)
        {
            leaf.transform.Rotate(0f,-90f,0f);
        }
    }

    public void CheckOriginalScale()
    {
        if(leaf.transform.localScale != scaleOrig)
        {
            leaf.transform.localScale = scaleOrig;
        }
    }

    public void CheckScaleAndZoom()
    {
        CheckRotation();
        if(leaf.transform.localPosition != moveOrig)
        {
            leaf.transform.localPosition = moveOrig;
        }

        if(leaf.transform.localScale != scaleDown && isVisible == false)
        {
            leaf.transform.localScale = scaleDown;
        }
    }

    public void CheckFadeUpAndDown()
    {
        CheckRotation();
        CheckOriginalScale();
    }

    public void CheckShakeAndRotate()
    {
        CheckOriginalScale();
        if(leaf.transform.localPosition != moveOrig)
        {
            leaf.transform.localPosition = moveOrig;
        }
    }
}
