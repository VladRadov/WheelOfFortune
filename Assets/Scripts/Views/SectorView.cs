using UnityEngine;
using UnityEngine.UI;

public class SectorView : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void ViewCoin(string value) => _text.text = value;
}
