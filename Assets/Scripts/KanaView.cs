using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KanaView : MonoBehaviour
{
    [SerializeField] private TMP_Text _kanaText;
    [SerializeField] private TMP_Text _romajiText;

    [SerializeField] private Button _nextKanaButton;
    [SerializeField] private Button _showButton;

    [SerializeField] private GameObject _gamePanel;

    private void Awake()
    {
        _kanaText.text = string.Empty;
        _romajiText.text = string.Empty;
    }

    public void SetButtonListeners(UnityEngine.Events.UnityAction onKanaSet,
        UnityEngine.Events.UnityAction onShowRomaji)
    {
        _nextKanaButton.onClick.RemoveAllListeners();
        _nextKanaButton.onClick.AddListener(() =>
        {
            onKanaSet();
            _romajiText.text = string.Empty;
        });

        _showButton.onClick.RemoveAllListeners();
        _showButton.onClick.AddListener(onShowRomaji);
    }

    public void SetKanaText(string text)
    {
        _kanaText.text = text;
    }

    public void SetRomajiText(string text)
    {
        _romajiText.text = text;
    }

    public string GetRomajiText()
    {
        return _kanaText.text;
    }

    public void ToggleGamePanelVisibility()
    {
        _gamePanel.SetActive(!_gamePanel.activeSelf);
    }

    public void ToggleRomajiVisibility()
    {
        _romajiText.gameObject.SetActive(!_romajiText.gameObject.activeSelf);
    }

    public void ShowRomaji()
    {
        if (!_romajiText.gameObject.activeSelf)
        {
            _romajiText.gameObject.SetActive(true);
        }
    }

    public void HideRomaji()
    {
        if (_romajiText.gameObject.activeSelf)
        {
            _romajiText.gameObject.SetActive(false);
        }
    }
}