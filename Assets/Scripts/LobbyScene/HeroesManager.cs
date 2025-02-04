using UnityEngine;

namespace LobbyScene
{
    public class HeroesManager : MonoBehaviour
    {
        public GameObject Player { get; protected internal set; }
        [SerializeField] public GameObject[] _playersPrefab;

        private void Awake()
        {
            var currentTag = GameController.Instance.SelectedHeroTag;
            Player = InstantiateSelectedHero(currentTag);
        }

        private GameObject InstantiateSelectedHero(string currentTag)
        {
            foreach (var heroPrefab in _playersPrefab)
            {
                if (!heroPrefab.CompareTag(currentTag)) continue;
                var instance = Instantiate(heroPrefab, transform);

                instance.SetActive(true);
                return instance;
            }

            return null;
        }
    }
}