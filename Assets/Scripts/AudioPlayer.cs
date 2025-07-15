using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource[] _soundEffects; 
    [SerializeField] private Button[] _playButtons; 

    private ToggleMuter toggleMuter;

    private void Awake()
    {
        toggleMuter = GetComponent<ToggleMuter>();

        for (int i = 0; i < _playButtons.Length; i++)
        {
            int index = i; 
            if (_playButtons[i] != null)
            {
                _playButtons[i].onClick.AddListener(() => PlaySound(index));
            }
        }

        if (toggleMuter != null)
            toggleMuter.OnMuteToggle += HandleMuteToggle;
    }

    private void PlaySound(int index)
    {
        if (_soundEffects == null || toggleMuter == null)
            return;

        if (index < 0 || index >= _soundEffects.Length)
            return;

        if (!toggleMuter.isMuted)
        {
            foreach (var sound in _soundEffects)
            {
                sound.Stop();
            }

            _soundEffects[index].Stop();
            _soundEffects[index].Play();
        }
    }

    private void HandleMuteToggle(bool isMuted)
    {
        if (_soundEffects != null)
        {
            foreach (var sound in _soundEffects)
            {
                if (isMuted)
                    sound.Pause();
                else if (!sound.isPlaying)
                    sound.UnPause();
            }
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _playButtons.Length; i++)
        {
            int index = i;

            if (_playButtons[i] != null)
                _playButtons[i].onClick.RemoveListener(() => PlaySound(index));
        }

        if (toggleMuter != null)
            toggleMuter.OnMuteToggle -= HandleMuteToggle;
    }
}
