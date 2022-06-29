using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultCanvas : MonoBehaviour
{
    [SerializeField] private PhotoCamera photoCamera;
    [SerializeField] private PictureManager picManager;
    [SerializeField] private Animator anim;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Camera renderCamera;
    [SerializeField] private GameObject effectTrans;

    private bool isNextMoveFrontPicture = true;

    public void Init()
    {
        canvasGroup.alpha = 1;
        renderCamera.enabled = true;
        (Texture2D[], int[], float[]) allPhotoInfo = photoCamera.GetAllPhotoInfo();
        picManager.GetAllPicture(allPhotoInfo.Item1, allPhotoInfo.Item2, allPhotoInfo.Item3);

        if(allPhotoInfo.Item1.Length <= 0)
        {
            FinishResult();
            return;
        }

        UpdatePicture();
        UpdatePicture();
        NextAnimation();
    }

    public void NextAnimation()
    {
        picManager.UpdateUI();

        if (isNextMoveFrontPicture) anim.SetTrigger("triMoveFront");
        else anim.SetTrigger("triMoveBack");
    }

    public void UpdatePicture()
    {
        Sprite nextPicture = picManager.GetNextTexture();
        if (nextPicture == null)
        {
            anim.SetBool("isLastPicture", true);
            return;
        }

        if (isNextMoveFrontPicture) picManager.FrontImg.sprite = nextPicture;
        else picManager.BackImg.sprite = nextPicture;

        isNextMoveFrontPicture = !isNextMoveFrontPicture;
    }

    private void FinishResult()
    {
        Debug.Log("Finish Result");
        effectTrans.SetActive(true);
        anim.enabled = false;
    }
}
