using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WheelView : MonoBehaviour
{
    [SerializeField] private Text _viewWinCoins;

    [SerializeField] private Button _buttonViewWinCoins;

    public IEnumerator ViewWinCoins(string value)
    {
        _buttonViewWinCoins.gameObject.SetActive(true);
        _viewWinCoins.text = value;
        yield return new WaitForSeconds(3.0f);
        _buttonViewWinCoins.gameObject.SetActive(false);
    }
}
