using UnityEngine;
using UnityEngine.UI;

public class Autoclicker : MonoBehaviour
{
    [Tooltip("Leave empty to use the Button on this same GameObject.")]
    [SerializeField] private Button _upgradeButton;

    [Tooltip("Which upgrade this button buys. Must match a name in upgrades.cs.")]
    [SerializeField] private string _upgradeName = "Autoclicker";

    [Tooltip("Leave empty to find the upgrades component in the scene automatically.")]
    [SerializeField] private upgrades _upgradeManager;

    private void Start()
    {

        if (_upgradeButton == null)
        {
            _upgradeButton = GetComponent<Button>();
        }

        if (_upgradeManager == null)
        {
            _upgradeManager = FindFirstObjectByType<upgrades>();
        }

        if (_upgradeButton == null)
        {
            Debug.LogError(
                $"{name}: no Button on this object and none assigned in the Inspector.",
                this);
            return;
        }

        if (_upgradeManager == null)
        {
            Debug.LogError(
                $"{name}: no upgrades component found in this scene. Add one, or " +
                "assign it in the Inspector.",
                this);
            return;
        }

        _upgradeButton.onClick.AddListener(OnButtonPressed);
    }

    private void OnButtonPressed()
    {
        _upgradeManager.upgrade_button_press(_upgradeName);
    }
}
