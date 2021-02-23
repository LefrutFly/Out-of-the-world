using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIinGame : MonoBehaviour
{
    [SerializeField] private GameObject hpImage;
    [SerializeField] private GameObject textHp;

    private void Start()
    {
        HpUpdate();
        PlayerBehaviour.player.hp.OnUIUpdate += () =>
        {
            HpUpdate();
        };
    }

    public void HpUpdate()
    {
        float hp = PlayerBehaviour.player.hp.GetHP();
        float hpMax = PlayerBehaviour.player.hp.GetHPMax();
        hpImage.GetComponent<Image>().fillAmount = hp / hpMax;
        textHp.GetComponent<Text>().text = hp + "/" + hpMax;
    }

    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
