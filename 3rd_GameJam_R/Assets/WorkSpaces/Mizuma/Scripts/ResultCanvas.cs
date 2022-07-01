using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultCanvas : MonoBehaviour
{
    [SerializeField] private PhotoCamera photoCamera;
    [SerializeField] private PictureManager picManager;
    [SerializeField] private Animator anim;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Camera renderCamera;
    [SerializeField] private GameObject effectTrans;
    [SerializeField] private GameObject finishText;
    private bool isNextMoveFrontPicture = true;
    private bool isCompResult = false;

    public void Init()
    {
        canvasGroup.alpha = 1;
        renderCamera.enabled = true;
        finishText.SetActive(false);

        (Texture2D[], int[], float[]) allPhotoInfo = photoCamera.GetAllPhotoInfo();
        picManager.SetAllPicture(allPhotoInfo.Item1, allPhotoInfo.Item2, allPhotoInfo.Item3);

        if(allPhotoInfo.Item1.Length <= 0)
        {
            FinishResult();
            return;
        }

        UpdatePicture();
        UpdatePicture();
        StartCoroutine(WaitStart(1.5f));
    }

    private void Update()
    {
        if (isCompResult == false) return;

        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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

    public void CompFinishResult()
    {
        isCompResult = true;
    }

    private IEnumerator WaitStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NextAnimation();
    }

    private void FinishResult()
    {
        Debug.Log("Finish Result");
        isCompResult = true;
        effectTrans.SetActive(true);
        anim.enabled = false;
        finishText.SetActive(true);
    }
}
