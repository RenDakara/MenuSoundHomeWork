using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private ToggleMuter _toggleMuter;
    [SerializeField] private SoundButtonController[] _soundControllers; 

    [SerializeField] private AudioSource _backGroundMusic;

    private void Awake()
    {
        foreach (var controller in _soundControllers)
        {
            controller.Initialize(_toggleMuter);
        }

        if (_toggleMuter != null)
            _toggleMuter.OnMuteToggle += HandleMuteToggle;
    }

    private void OnDestroy()
    {
        foreach (var controller in _soundControllers)
        {
            controller.Cleanup();
        }

        if (_toggleMuter != null)
            _toggleMuter.OnMuteToggle -= HandleMuteToggle;
    }

    private void HandleMuteToggle(bool isMuted)
    {
        if (_backGroundMusic != null)
        {
            if (isMuted)
                _backGroundMusic.Pause();
            else if (!_backGroundMusic.isPlaying)
                _backGroundMusic.UnPause();
        }
    }
}
