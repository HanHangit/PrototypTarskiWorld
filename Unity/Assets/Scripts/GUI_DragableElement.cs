using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUI_DragableElement : MonoBehaviour
{
    [SerializeField]
    private string _identifier = "";

    [SerializeField]
    private Image _image = default;
    [SerializeField]
    private Sprite _targetSprite = default;

    public void StartDragging(string identifier, Sprite sprite)
    {
        _identifier = identifier;
        _image.sprite = sprite;
        _targetSprite = sprite;
    }

    private void Update()
    {
        this.transform.position = Input.mousePosition;
    }


}
