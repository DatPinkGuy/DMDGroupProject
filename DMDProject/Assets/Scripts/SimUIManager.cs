using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimUIManager : MonoBehaviour
{
    [SerializeField] private Text _npcName;
    [SerializeField] private Text _npcDetails;
    [SerializeField] private Image _npcImage;
    [SerializeField] private GameObject _ui;

    private void Awake()
    {
        DisableUI();
    }

    public void AddinfoToUI(string _name, string _detail, Sprite _image)
    {
        ;
        _npcName.text = _name;
        _npcDetails.text = _detail;
        _npcImage.GetComponent<Image>().sprite = _image;
    }

    public void DisableUI()
    {
        _ui.SetActive(false);
    }

    public void EnableUI()
    {
        _ui.SetActive(true);
    }
}
