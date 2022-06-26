using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureManager : MonoBehaviour
{
    [SerializeField] private ResultUI resultUI;
    [SerializeField] private Image backImg;
    [SerializeField] private Canvas backCanvas;
    [SerializeField] private Image frontImg;
    [SerializeField] private Canvas frontCanvas;

    private Texture2D[] pictures;
    public int[] copyCntArr;
    public float[] minObjDistanceArr;
    public int currentPicIndex = 0;
    private int currentInfoIndex = 0;

    public Image BackImg => backImg;
    public Image FrontImg => frontImg;
    public int[] CopyCntArr => copyCntArr;
    public float[] MinObjDistanceArr => minObjDistanceArr;

    public void GetAllPicture(Texture2D[] pictures, int[] copyObjArr, float[] minObjDistanceArr)
    {
        Array.Resize<Texture2D>(ref this.pictures, pictures.Length);
        this.pictures = pictures;

        Array.Resize<int>(ref this.copyCntArr, copyObjArr.Length);
        this.copyCntArr = copyObjArr;

        Array.Resize<float>(ref this.minObjDistanceArr, minObjDistanceArr.Length);
        this.minObjDistanceArr = minObjDistanceArr;
    }

    public void UpdateUI()
    {
        resultUI.UpdateInfoUI(copyCntArr[currentInfoIndex], minObjDistanceArr[currentInfoIndex]);
        currentInfoIndex++;
    }

    public Sprite GetNextTexture()
    {
        if (currentPicIndex >= pictures.Length) return null;

        Texture2D tex = pictures[currentPicIndex];
        currentPicIndex++;
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
        return sprite;
    }

    public void ChgLayerOrder()
    {
        if(backCanvas.sortingOrder == 0)
        {
            backCanvas.sortingOrder = 1;
            frontCanvas.sortingOrder = 0;
        }
        else
        {
            backCanvas.sortingOrder = 0;
            frontCanvas.sortingOrder = 1;
        }
    }

    public void UpdateTotalUIFirstColumn()
    {
        resultUI.UpdateTotalUIFirstColumn();
    }

    public void UpdateTotalUISecondColumn()
    {
        resultUI.UpdateTotalUISecondColumn();
    }
}
