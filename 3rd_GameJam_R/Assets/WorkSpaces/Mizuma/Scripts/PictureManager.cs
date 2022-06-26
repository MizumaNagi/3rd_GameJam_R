using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureManager : MonoBehaviour
{
    [SerializeField] private Image backImg;
    public Image BackImg => backImg;
    [SerializeField] private Canvas backCanvas;
    [SerializeField] private Image frontImg;
    public Image FrontImg => frontImg;
    [SerializeField] private Canvas frontCanvas;

    private Texture2D[] pictures;
    private int currentPicIndex = 0;

    public void GetAllPicture(List<Texture2D> pictures)
    {
        Array.Resize<Texture2D>(ref this.pictures, pictures.Count);
        this.pictures = pictures.ToArray();
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
}
