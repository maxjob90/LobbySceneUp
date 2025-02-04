using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LobbyScene
{
    public class GameController : MonoBehaviour
    {
        [field: SerializeField] public string SelectedHeroTag { get; private set; }
        private static GameController _instance;
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] public TextMeshProUGUI _coin;
        public string _lvlHero;
        public string _infoLvlHero;

        public static GameController Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = FindObjectOfType<GameController>();

                if (_instance == null)
                {
                    var singleton = new GameObject("GameController");
                    _instance = singleton.AddComponent<GameController>();
                }

                if (_instance != null)
                {
                    DontDestroyOnLoad(_instance);
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                _instance._mainMenu.SetActive(true);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        public void SetSelectedHeroTag(string tag)
        {
            SelectedHeroTag = tag;
        }

        public void ChangeSceneHeroSelectionScene()
        {
            _mainMenu.SetActive(false);
            SceneManager.LoadScene("HeroSelectionScene");
        }
    }
}