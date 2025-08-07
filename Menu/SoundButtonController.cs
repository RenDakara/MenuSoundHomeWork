using UnityEngine;
using UnityEngine.UI;

public class SoundButtonController : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _soundEffect;
    [SerializeField] private AudioSource[] _otherSounds;

    private ToggleMuter toggleMuter;

    public void Initialize(ToggleMuter muter)
    {
        toggleMuter = muter;
        if (_button != null)
        {
            _button.onClick.AddListener(OnButtonClicked);
        }
    }

    private void OnButtonClicked()
    {
        if (toggleMuter == null || _soundEffect == null)
            return;

        if (!toggleMuter.isMuted)
        {
            foreach (var sound in _otherSounds)           
                sound.Stop();
            
            _soundEffect.Play();
        }
    }

    public void Cleanup()
    {
        if (_button != null)
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }
    }
}
