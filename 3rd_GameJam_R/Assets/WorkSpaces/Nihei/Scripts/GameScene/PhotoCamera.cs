using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCamera : MonoBehaviour
{
    [SerializeField]
    private Image enableTakeLamp = null;
    [SerializeField]
    private Rect takeValidRect = new Rect();
    [SerializeField]
    private KeyCode takeKey = KeyCode.Space;
    [SerializeField]
    private float takeCoolTime = 1.0f;
    [SerializeField]
    private float takeMaxDistance = 100.0f;

    private Camera projectionCamera = null;
    private ActionTimer takeTimer = new ActionTimer();
    private bool enableTakePhoto = false;

    private List<Texture2D> takenPhotoList = new List<Texture2D>();
    private List<int> copyCntList = new List<int>();
    private List<float> birdMinDistanceList = new List<float>();

    private void Awake()
    {
        projectionCamera = GetComponentInChildren<Camera>();
        takeTimer.activateTime = takeCoolTime;
        takeTimer.action = () => { SetEnableToTakePhoto(); };
    }

    private void Update()
    {
        takeTimer.UpdateTimer();
        UpdateInputTakePhoto();
    }

    /// <summary>
    /// ���͂��m�F���A�ʐ^���B�邩�ǂ����̍X�V���s��
    /// </summary>
    private void UpdateInputTakePhoto()
    {
        if (!enableTakePhoto) return;
        if (Input.GetKeyDown(takeKey))
        {
            TakePhoto();
        }
    }

    /// <summary>
    /// �B�e��L���ɂ���
    /// </summary>
    private void SetEnableToTakePhoto()
    {
        enableTakePhoto = true;
        enableTakeLamp.color = Color.green;

        AudioManager.Instance.PlaySE("CameraShutterOpen");
    }

    /// <summary>
    /// �B�e�𖳌��ɂ���
    /// </summary>
    private void SetDisableToTakePhoto()
    {
        enableTakePhoto = false;
        enableTakeLamp.color = Color.red;
    }

    /// <summary>
    /// �ʐ^���B��
    /// </summary>
    private void TakePhoto()
    {
        GameObject[] photoTargetObjs = GameObject.FindGameObjectsWithTag(LayerTagUtil.TagNamePhotoTarget);
        RaycastHit targetRaycastHit;
        int copyCntInPhoto = 0;
        float birdMinDistance = Mathf.Infinity;
        foreach(GameObject photoTargetObj in photoTargetObjs)
        {
            PhotoTarget photoTarget = photoTargetObj.GetComponent<PhotoTarget>();
            if (photoTarget == null) continue;

            Vector3 targetViewPoint = projectionCamera.WorldToViewportPoint(photoTarget.TargetOriginTrans.position);
            // �Ώە����B�锻��̗L���͈͂ɓ����Ă��Ȃ��ꍇ�͑ΏۊO
            if (!takeValidRect.Contains(targetViewPoint)) continue;
            Vector3 cameraPosition = projectionCamera.transform.position;
            Vector3 targetDirection = photoTarget.TargetOriginTrans.position - cameraPosition;
            // �J��������Ώە��Ɍ�����Ray���΂��A�Ώە��Ƀq�b�g���Ȃ������ꍇ�͑ΏۊO
            if (!Physics.Raycast(projectionCamera.transform.position, targetDirection, out targetRaycastHit, takeMaxDistance)) continue;

            PhotoTarget raycastHitPhotoTarget = targetRaycastHit.transform.GetComponentInParent<PhotoTarget>();
            // Ray���q�b�g�����I�u�W�F�N�g��PhotoTarget�R���|�[�l���g���Ȃ���ΑΏۊO
            if (raycastHitPhotoTarget == null) continue;
            if (raycastHitPhotoTarget.transform != photoTarget.transform) continue;

            photoTarget.OnTakenPhoto();

            // �B�e���J�E���g, ���ƃJ�����̍ŒZ�����X�V�m�F
            copyCntInPhoto++;
            float targetDistance = targetRaycastHit.distance;
            if (targetDistance < birdMinDistance) birdMinDistance = targetDistance;
        }

        takeTimer.ResetTimer();
        SetDisableToTakePhoto();

        AudioManager.Instance.PlaySE("CameraShutter");

        // �B�����ʐ^�����X�g�ɒǉ�����
        RenderTexture cameraTexture = projectionCamera.targetTexture;
        Texture2D takenPhoto = new Texture2D(cameraTexture.width, cameraTexture.height, TextureFormat.RGBA32, false);
        Graphics.CopyTexture(projectionCamera.targetTexture, takenPhoto);

        Debug.Log($"copyCnt: {copyCntInPhoto} / distance: {birdMinDistance}");

        takenPhotoList.Add(takenPhoto);
        copyCntList.Add(copyCntInPhoto);
        birdMinDistanceList.Add(birdMinDistance);
    }

    public (Texture2D[], int[], float[]) GetAllPhotoInfo()
    {
        return (takenPhotoList.ToArray(), copyCntList.ToArray(), birdMinDistanceList.ToArray());
    }
}
