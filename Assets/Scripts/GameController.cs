using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    [SerializeField] private Button _katakanaModeButton;
    [SerializeField] private Button _hiraganaModeButton;
    [SerializeField] private Button _backButton;
  
    [SerializeField] private KanaController _kanaController;
    
    private void Awake()
    {
        _katakanaModeButton.onClick.AddListener(() => _kanaController.StartMode(Mode.Katakana));
        _hiraganaModeButton.onClick.AddListener(() => _kanaController.StartMode(Mode.Hiragana));
        _backButton.onClick.AddListener(() => _kanaController.StopMode());
    }
}
