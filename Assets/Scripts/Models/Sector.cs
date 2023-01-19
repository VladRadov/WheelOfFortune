using UnityEngine;

public class Sector : MonoBehaviour
{
    private bool _isSelected;

    [SerializeField] private string _coin;

    [SerializeField] private SectorView _sectorView;

    public string Coin => _coin;

    public bool IsSelected => _isSelected;

    private void Start()
    {
        _isSelected = false;
        _sectorView.ViewCoin(_coin);
    }

    private void OnTriggerStay2D(Collider2D collision) => SetSelected(collision, true);

    private void OnTriggerExit2D(Collider2D collision) => SetSelected(collision, false);

    private void SetSelected(Collider2D collision, bool value)
    {
        if (collision.gameObject.layer == 3)
            _isSelected = value;
    }
}
