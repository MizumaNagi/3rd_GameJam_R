using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureManager : MonoBehaviour
{
    [SerializeField] private Image backImg;
    [SerializeField] private Canvas backCanvas;
    [SerializeField] private Image frontImg;
    [SerializeField] private Canvas frontCanvas;

    private List<Texture2D> texList = new List<Texture2D>();

    public void UpdatePicture(Texture2D tex)
    {
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
        frontImg.sprite = sprite;
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
