using LobbyScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeroSelectionScene
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Heroes _heroes;

        public void ChangeSceneLobbyScene()
        {
            GameController.Instance.SetSelectedHeroTag(_heroes._name.text);
            SceneManager.LoadScene("LobbyScene");
        }
    }
}