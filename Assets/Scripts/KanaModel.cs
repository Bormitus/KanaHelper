using System.Collections.Generic;
using UnityEngine;

public enum Mode
{
    Hiragana,
    Katakana
}

public class KanaModel
{
    private List<char> _hiraganaList = new List<char>();
    private List<char> _katakanaList = new List<char>();
    private List<string> _romajiList = new List<string>();
    
    private List<char> _currentKanaList = new List<char>();
    private List<string> _currentRomajiList = new List<string>();

    public string RomajiSet { get; private set; } = new string("");
    public string KanaSet { get; private set; } = new string("");

    public Mode CurrentMode { get; private set; }
    
    public void Init(string hiraganaData, string katakanaData, string romajiData, Mode mode)
    {
        _hiraganaList = new List<char>(hiraganaData);
        _katakanaList = new List<char>(katakanaData);
        _romajiList = new List<string>(romajiData.Split(' '));
        CurrentMode = mode;
        SetKanaList();
    }

    public void GenerateRandomKana()
    {
        KanaSet = "";
        RomajiSet = "";
        
        for (int i = 0; i < 5; i++)
        {
            int index = Random.Range(0, _currentKanaList.Count);
            KanaSet += _currentKanaList[index] + " ";
            RomajiSet += _currentRomajiList[index] + " ";
            
            _currentKanaList.RemoveAt(index);
            _currentRomajiList.RemoveAt(index);
            if (_currentKanaList.Count == 0)
            {
                SetKanaList();
                break;
            }
        }
    }

    public void SetKanaList()
    {
        switch (CurrentMode)
        {
            case Mode.Hiragana:
                _currentKanaList = new List<char>(_hiraganaList);
                break;
            case Mode.Katakana:
                _currentKanaList = new List<char>(_katakanaList);
                break;
        }
        _currentRomajiList =  new List<string>(_romajiList);

    }

}