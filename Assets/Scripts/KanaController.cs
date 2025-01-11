using System;
using System.Collections.Generic;
using UnityEngine;

public class KanaController : MonoBehaviour
{
    private KanaModel _kanaModel = new KanaModel();
    [SerializeField] private KanaView _kanaView;

    [SerializeField] private TextAsset _hiraganaTextFile;
    [SerializeField] private TextAsset _katakanaTextFile;
    [SerializeField] private TextAsset _romajiTextFile;

    private void Awake()
    {
        _kanaView.SetButtonListeners(ShowKanaSet, ShowRomajiSet);
    }

    public void StartMode(Mode mode)
    {
        _kanaModel.Init(_hiraganaTextFile.text, _katakanaTextFile.text, _romajiTextFile.text, mode);

        ShowKanaSet();
        
        _kanaView.ToggleGamePanelVisibility();
    }

    public void StopMode()
    {
        _kanaView.HideRomaji();
        _kanaView.ToggleGamePanelVisibility();
    }

    private void ShowKanaSet()
    {
        _kanaModel.GenerateRandomKana();
        string kana = _kanaModel.KanaSet;
        
        _kanaView.SetKanaText(kana);
        _kanaView.HideRomaji();
    }

    public void ShowRomajiSet()
    {
        if (_kanaView.GetRomajiText() != _kanaModel.RomajiSet)
        {
            string romaji = _kanaModel.RomajiSet;
            _kanaView.SetRomajiText(romaji);
        }
        
        _kanaView.ToggleRomajiVisibility();
    }
}