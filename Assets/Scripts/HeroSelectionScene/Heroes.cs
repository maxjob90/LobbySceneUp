using LobbyScene;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using RectTransform = UnityEngine.RectTransform;
using Slider = UnityEngine.UI.Slider;

namespace HeroSelectionScene
{
    public class Heroes : MonoBehaviour
    {
        private GameObject[] _heroes;
        private static string[] _tagsHero;
        private GameObject _player;
        private int _index;
        private bool _checkPrice;

        [SerializeField] private UnityEngine.UI.Button _priceHero;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private UnityEngine.UI.Button _selectHero;

        [SerializeField] public TextMeshProUGUI _name;

        [SerializeField] private Image _bow;
        [SerializeField] private Image _magic;
        [SerializeField] private Image _icon;

        [SerializeField] private TextMeshProUGUI _lvlHero;
        [SerializeField] private TextMeshProUGUI _infoLvl;
        [SerializeField] private TextMeshProUGUI _weaponInfo;
        [SerializeField] private Slider _health;
        [SerializeField] private Slider _attack;
        [SerializeField] private Slider _defense;
        [SerializeField] private Slider _speed;


        public void ClickButtonPrice()
        {
            var coin = int.Parse(GameController.Instance._coin.text) - int.Parse(_price.text);
            GameController.Instance._coin.text = coin.ToString();

            for (var i = 0; i < _tagsHero.Length; i++)
            {
                if (_player.CompareTag(_heroes[i].tag))
                {
                    _tagsHero[i] = null;
                }
            }

            _checkPrice = true;
        }

        private void Update()
        {
            if (_checkPrice)
            {
                for (var i = 0; i < _tagsHero.Length; i++)
                {
                    if (_tagsHero[i] != null || !_heroes[i].CompareTag(_player.tag)) continue;
                    _priceHero.gameObject.SetActive(false);
                    _selectHero.interactable = true;
                    var y = _selectHero.GetComponent<RectTransform>().anchoredPosition.y;
                    _selectHero.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y);
                }

                _checkPrice = false;
            }

            if (GameController.Instance.SelectedHeroTag != _name.text)
            {
                _name.text = GameController.Instance.SelectedHeroTag;
            }

            switch (_name.text)
            {
                case "Bow02":
                    _icon.gameObject.SetActive(false);
                    _magic.gameObject.SetActive(false);
                    _bow.gameObject.SetActive(true);
                    _lvlHero.text = "2";
                    _infoLvl.text = "31/100";
                    _weaponInfo.text = "Bow hero";
                    _health.value = 0.8f;
                    _attack.value = 0.3f;
                    _defense.value = 0.2f;
                    _speed.value = 0.7f;
                    break;
                case "MagicWand01":
                    _icon.gameObject.SetActive(false);
                    _bow.gameObject.SetActive(false);
                    _magic.gameObject.SetActive(true);
                    _lvlHero.text = "3";
                    _infoLvl.text = "77/100";
                    _weaponInfo.text = "Magic Wand hero";
                    _health.value = 0.4f;
                    _attack.value = 0.1f;
                    _defense.value = 0.5f;
                    _speed.value = 0.99f;
                    break;
                case "DoubleSword05":
                    _icon.gameObject.SetActive(true);
                    _bow.gameObject.SetActive(false);
                    _magic.gameObject.SetActive(false);
                    _lvlHero.text = "2";
                    _infoLvl.text = "66/100";
                    _weaponInfo.text = "Double Sword hero";
                    _health.value = 0.4f;
                    _attack.value = 0.5f;
                    _defense.value = 0.6f;
                    _speed.value = 0.2f;
                    break;
                case "NoWeapon01":
                    _icon.gameObject.SetActive(true);
                    _bow.gameObject.SetActive(false);
                    _magic.gameObject.SetActive(false);
                    _lvlHero.text = "1";
                    _infoLvl.text = "48/100";
                    _weaponInfo.text = "No weapon hero";
                    _health.value = 0.6f;
                    _attack.value = 0.8f;
                    _defense.value = 0.99f;
                    _speed.value = 0.3f;
                    break;
                case "SwordShield03":
                    _icon.gameObject.SetActive(true);
                    _bow.gameObject.SetActive(false);
                    _magic.gameObject.SetActive(false);
                    _lvlHero.text = "5";
                    _infoLvl.text = "07/100";
                    _weaponInfo.text = "Sword Shield hero";
                    _health.value = 0.1f;
                    _attack.value = 0.5f;
                    _defense.value = 0.8f;
                    _speed.value = 0.9f;
                    break;
                case "TwoHandsSword02":
                    _icon.gameObject.SetActive(true);
                    _bow.gameObject.SetActive(false);
                    _magic.gameObject.SetActive(false);
                    _lvlHero.text = "7";
                    _infoLvl.text = "93/100";
                    _weaponInfo.text = "Two Hands Sword hero";
                    _health.value = 0.5f;
                    _attack.value = 0.99f;
                    _defense.value = 0.1f;
                    _speed.value = 0.88f;
                    break;
            }

            GameController.Instance._lvlHero = _lvlHero.text;
            GameController.Instance._infoLvlHero = _infoLvl.text;
        }

        private void Awake()
        {
            if (_priceHero.IsActive())
            {
                _selectHero.interactable = false;
            }

            _heroes = FindObjectOfType<HeroesManager>()._playersPrefab;
            _player = FindObjectOfType<HeroesManager>().Player;
            if (_tagsHero == null)
            {
                _tagsHero = new string[6];


                for (var i = 0; i < _heroes.Length; i++)
                {
                    _tagsHero[i] = _heroes[i].tag;

                    if (!_heroes[i].CompareTag(GameController.Instance.SelectedHeroTag)) continue;
                    _index = i;
                    _player = _heroes[i];
                    _tagsHero[i] = null;
                }
            }

            _checkPrice = true;
        }

        public void ShowNext()
        {
            _index = (_index + 1) % _heroes.Length;
            ShowSelectedHero();
        }

        public void ShowPrevious()
        {
            _index = (_index - 1 + _heroes.Length) % _heroes.Length;
            ShowSelectedHero();
        }

        private void ShowSelectedHero()
        {
            Destroy(GameObject.FindGameObjectWithTag(_player.tag));
            foreach (var hero in _heroes)
            {
                hero.SetActive(false);
            }

            var heroToShow = _heroes[_index];
            heroToShow.SetActive(true);
            Instantiate(heroToShow, FindObjectOfType<HeroesManager>().gameObject.transform);
            GameController.Instance.SetSelectedHeroTag(heroToShow.tag);
            _name.text = heroToShow.tag;
            _player = _heroes[_index];
            FindObjectOfType<HeroesManager>().Player = _heroes[_index];
            if (_checkPrice) return;
            _priceHero.gameObject.SetActive(true);
            _selectHero.interactable = false;
            var y = _selectHero.GetComponent<RectTransform>().anchoredPosition.y;
            var x = _priceHero.GetComponent<RectTransform>().anchoredPosition.x;
            _selectHero.GetComponent<RectTransform>().anchoredPosition = new Vector3(-x, y);

            _checkPrice = true;
        }
    }
}