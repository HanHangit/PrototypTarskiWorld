using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class GUI_SpawnDragableElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private GUI_ObjectButton _objectButton = default;
    [SerializeField]
    private GUI_DragableElement _dragElementPrefab = default;
    private GUI_DragableElement _dragInstance = default;
    [SerializeField]
    private Transform _anchor = default;

    private void OnValidate()
    {
        if (_objectButton == null)
        {
            _objectButton = GetComponent<GUI_ObjectButton>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_dragElementPrefab)
        {
            _dragInstance = Instantiate(_dragElementPrefab, _anchor);
            _dragInstance.transform.position = Input.mousePosition;
            _dragInstance.StartDragging(_objectButton.GetIdentifier(), _objectButton.GetSprite());
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        foreach (var item in eventData.hovered)
        {
            var dragableTarget = item.GetComponent<IDragableTarget>();

            if (dragableTarget != null)
            {
                dragableTarget.OnDragEnd(_objectButton.GetSprite(), _objectButton.GetIdentifier(), _objectButton.GetCurrentTyp());
            }
        }
        Destroy(_dragInstance.gameObject);
    }
}
