using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneChangeButton : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private Button _button;
    
    private void OnEnable()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(LoadSceneByName);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(LoadSceneByName);
    }

    private void LoadSceneByName()
    {
        SceneManager.LoadScene(sceneName);
    }
}
