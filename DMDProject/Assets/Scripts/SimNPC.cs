using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimNPC : MonoBehaviour
{
    private SimUIManager _uiManager;
    [SerializeField] public string _npcName;
    [TextArea(3, 5)] [SerializeField] public string _details;
    [SerializeField] public Sprite _image;


    private void Awake()
    {
        _uiManager = GameObject.FindObjectOfType<SimUIManager>();
    }

    void Update()
    {
        if (IsTouched()) // if this thing was clicked
        {
            Debug.Log("Clicked");
            _uiManager.EnableUI();
            _uiManager.AddinfoToUI(this._npcName, this._details, this._image);
        }
    }
    public bool IsTouched()
    {
        bool _result = false;
        if (Input.touchCount == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Ended) // touchscreen click
            {
                Vector3 _windowPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Vector2 _touchPos = new Vector2(_windowPos.x, _windowPos.y);
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(_touchPos))
                {
                    _result = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0)) //mouse input click
        {
            Vector3 _windowPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 _mousePos = new Vector2(_windowPos.x, _windowPos.y);
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(_mousePos))
            {
                _result = true;
            }
        }
        return _result;
    }
}
