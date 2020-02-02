using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixerSnapshot waitingSnapshot;
    public AudioMixerSnapshot fightSnapshot;
    public AudioMixerSnapshot bossFightSnapshot;
    public AudioMixerSnapshot mutedSnapshot;

    #region singleton
    public static SoundManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        waitingSnapshot.TransitionTo(0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FightSoundTrack()
    {
        fightSnapshot.TransitionTo(0.3f);
    }

    public void WaitingSoundtrack()
    {
        waitingSnapshot.TransitionTo(0.3f);
    }

    public void BossFightSoundTrack()
    {
        bossFightSnapshot.TransitionTo(0.3f);
    }

    public void AllSoundsAway()
    {
        mutedSnapshot.TransitionTo(0.3f);
    }
    
}
