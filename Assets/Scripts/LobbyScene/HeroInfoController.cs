using LobbyScene;
using TMPro;
using UnityEngine;

public class HeroInfoController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameHero;
    [SerializeField] public TextMeshProUGUI _lvlHero;
    [SerializeField] public TextMeshProUGUI _infoLvlHero;

    private void Update()
    {
        if (GameController.Instance.SelectedHeroTag == _nameHero.text) return;
        _nameHero.text = GameController.Instance.SelectedHeroTag;
        _lvlHero.text = GameController.Instance._lvlHero;
        _infoLvlHero.text = GameController.Instance._infoLvlHero;
    }
}