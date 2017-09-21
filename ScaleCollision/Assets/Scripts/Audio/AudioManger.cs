using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioUnit
{
    private string mAudioId = string.Empty;
    public string AudioId { get { return mAudioId; } }

    private EnumDataDef.AudioType mAudioType = EnumDataDef.AudioType.BgMusic;
    public EnumDataDef.AudioType AudioType { get { return mAudioType; } }

    private AudioSource mAudioSource = null;
    public AudioSource AudioSource { get { return mAudioSource; } }

    public AudioUnit()
    {

    }

    public AudioUnit(string id, EnumDataDef.AudioType type, AudioSource source)
    {
        mAudioId = id;
        mAudioType = type;
        mAudioSource = source;
    }

    public void Play(float delay)
    {
        if(null != mAudioSource)
        {
            //Debug.LogError("hyy");
            if (!mAudioSource.gameObject.activeSelf)
            {
                mAudioSource.gameObject.SetActive(true);
            }
            mAudioSource.enabled = true;
            mAudioSource.PlayDelayed(delay);
        }
    }

    public void Stop()
    {
        if(null != mAudioSource)
        {
            if (mAudioSource.gameObject.activeSelf ) {
                mAudioSource.gameObject.SetActive(false);
            }
            mAudioSource.Stop();
            mAudioSource.enabled = false;
        }
    }

    public void ResumeAudio(bool resume)
    {
        if(resume)
        {
            UnPause();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        if(null != mAudioSource)
        {
            mAudioSource.Pause();
        }
    }

    public void UnPause()
    {
        if(null != mAudioSource)
        {
            mAudioSource.UnPause();
        }
    }

    public void Destroy()
    {
        if(null != mAudioSource)
        {
            Object.Destroy(mAudioSource.gameObject);
        }
    }
}

public class AudioManager
{
    private const string AUDIO_PATH = "Audio/{0}";
    private const string AUDIO_OBJECT_NAME = "Audio_{0}"; 

    private static System.Object mLock = new System.Object();
    private static AudioManager mInstance = null;
    public static AudioManager Instance
    {
        get
        {
            lock(mLock)
            {
                if(null == mInstance)
                {
                    mInstance = new AudioManager();
                }

                return mInstance;
            }
        }
    }

    private Dictionary<string, AudioUnit> AudioDic = new Dictionary<string, AudioUnit>();

//    public AudioUnit PlayAudio(string audioId, Transform sender = null,bool loop = false, bool isPlayOnAwake = true, EnumDataDef.AudioType type = EnumDataDef.AudioType.Sound, float delay = 0f)
//    {
//        if(string.IsNullOrEmpty(audioId))
//        {
//            return null;
//        }
//
//        if(type == EnumDataDef.AudioType.BgMusic)
//        {
//            if (!DataCenter.Instance.PlayerData.isMusicOpen)
//            {
//                return null;
//            }
//        }
//        else
//        {
//            if (!DataCenter.Instance.PlayerData.isSoundOpen)
//            {
//                return null;
//            }
//        }
//        AudioUnit unit;
//        if(!AudioDic.ContainsKey(audioId))
//        {
//            AudioClip clip = Resources.Load<AudioClip>(string.Format(AUDIO_PATH, audioId));
//            if(clip == null) 
//            {
//                Logger.Error(string.Format(AUDIO_PATH, audioId));
//                return null;
//            }
//            GameObject go = new GameObject(string.Format(AUDIO_OBJECT_NAME, audioId));
//            go.transform.parent = CameraManager.Instance.pMainCamera.pCamera.transform;
//            go.transform.localPosition = Vector3.zero;
//            AudioSource audioSrc = go.AddComponent<AudioSource>();
//            audioSrc.clip = clip;
//            audioSrc.loop = loop;
//            audioSrc.playOnAwake = isPlayOnAwake;
//            if (isPlayOnAwake)
//            {
//                audioSrc.PlayDelayed(delay);
//            }
//            unit = new AudioUnit(audioId, type, audioSrc);
//            AudioDic.Add(audioId, unit);
//        }
//        else
//        {
//            unit = AudioDic[audioId];
//            if (null != unit)
//            {
//                if (unit.pAudioSource.isPlaying)
//                {
//                    unit.Stop();
//                }
//                unit.Play(delay);
//            }
//        }
//        //Debug.Log(audioId);
//        return unit;
//    }
//
//    public AudioUnit PlayAudioList(string audioId, Transform sender = null, bool loop = false, bool isPlayOnAwake = true, EnumDataDef.AudioType type = EnumDataDef.AudioType.Sound, float delay = 0f)
//    {
//        if (string.IsNullOrEmpty(audioId))
//        {
//            return null;
//        }
//
//        if (type == EnumDataDef.AudioType.BgMusic)
//        {
//            if (!DataCenter.Instance.PlayerData.IsMusicOpen)
//            {
//                return null;
//            }
//        }
//        else
//        {
//            if (!DataCenter.Instance.PlayerData.IsSoundOpen)
//            {
//                return null;
//            }
//        }
//        AudioUnit unit;
//        AudioClip clip = Resources.Load<AudioClip>(string.Format(AUDIO_PATH, audioId));
//        if (clip == null)
//        {
//            Logger.Error(string.Format(AUDIO_PATH, audioId));
//            return null;
//        }
//        GameObject go = new GameObject(string.Format(AUDIO_OBJECT_NAME, audioId));
//        go.transform.parent = CameraManager.Instance.pMainCamera.pCamera.transform;
//        go.transform.localPosition = Vector3.zero;
//        AudioSource audioSrc = go.AddComponent<AudioSource>();
//        audioSrc.clip = clip;
//        audioSrc.loop = loop;
//        audioSrc.playOnAwake = isPlayOnAwake;
//        if (isPlayOnAwake)
//        {
//            audioSrc.PlayDelayed(delay);
//        }
//        unit = new AudioUnit(audioId, type, audioSrc);
//        //AudioDic.Add(audioId, unit);
//        return unit;
//    }
//
//    public float GetAudioTime(string audioId)
//    {
//        if(AudioDic.ContainsKey(audioId))
//        {
//            return AudioDic[audioId].pAudioSource.clip.length;
//        }
//        return 0;
//    }
//
//    public void StopAudio(string audioId)
//    {
//        if(AudioDic.ContainsKey(audioId))
//        {
//            AudioDic[audioId].Stop();
//        }
//    }
//
//    public void StopAllAudio()
//    {
//        foreach (string keyValue in AudioDic.Keys)
//        {
//            AudioDic[keyValue].Stop();
//        }
//    }
//
//    public void StopAllMusic()
//    {
//        foreach (string keyValue in AudioDic.Keys)
//        {
//            if (EnumDataDef.AudioType.Sound == AudioDic[keyValue].pAudioType)
//            {
//                AudioDic[keyValue].Stop();
//            }
//        }
//    }
//
//    public void StopBackground()
//    {
//        foreach (string keyValue in AudioDic.Keys)
//        {
//            if (EnumDataDef.AudioType.BgMusic == AudioDic[keyValue].pAudioType)
//            {
//                AudioDic[keyValue].Stop();
//            }
//        }
//    }
//
//    public bool IsHasAudio(string audioId)
//    {
//        return AudioDic.ContainsKey(audioId);
//    }
//
//    /// <summary>
//    /// Determines whether this instance is audio playing the specified audioType.
//    /// 判断当前音乐音效是否正在播放
//    /// </summary>
//    /// <returns><c>true</c> if this instance is audio playing the specified audioType; otherwise, <c>false</c>.</returns>
//    /// <param name="audioType">Audio type.</param>
//    public bool IsAudioPlaying(string audioId)
//    {
//        bool isPlaying = false;
//        if(AudioDic.ContainsKey(audioId))
//        {
//            AudioUnit unit = AudioDic[audioId];
//            if (unit != null)
//            {
//                isPlaying = unit.pAudioSource.isPlaying;
//            }
//        }
//        return isPlaying;
//    }
//
//    public void RemoveAudio(string audioId)
//    {
//        if(AudioDic.ContainsKey(audioId))
//        {
//            AudioDic[audioId].Destroy();
//            AudioDic.Remove(audioId);
//        }
//    }
//
//    public void ClearAllAudio()
//    {
//        if(AudioDic != null)
//        {
//            foreach(string keyValue in AudioDic.Keys)
//            {
//                AudioDic[keyValue].Stop();
//            }
//            //AudioDic.Clear();
//        }
//    }
//
//    public AudioUnit GetAudioUnit(string id)
//    {
//        if (AudioDic.ContainsKey(id))
//        {
//            return AudioDic[id];
//        }
//        return null;
//    }
//
//
//    protected override void OnSystemInit()
//    {
//        base.OnSystemInit();
//
//        ResGameObject rgo = ObjectLoader.LoadGameObject("Prefabs/Audio/AMI", false);
//        if (null != rgo)
//        {
//            GameObject obj = GameObject.Instantiate<GameObject>(rgo.pPrefab);
//            if (null != obj)
//            {
//                //obj.transform.SetParent(null);
//                obj.name = "AMI";
//                obj.transform.parent = null;
//                GameObject.DontDestroyOnLoad(obj);
//            }
//            rgo.Destroy();
//        }
//
//    }
//
//
//    protected override void OnSystemLevelGoingUnload()
//    {
//        base.OnSystemLevelGoingUnload();
//        //ClearAllAudio(); 
//        StopBackground();
//
//        //停止循环音乐
//        foreach (var xaudio in AudioDic)
//        {
//            if (xaudio.Value.pAudioSource.loop)
//            {
//                if (IsAudioPlaying(xaudio.Key))
//                {
//                    StopAudio(xaudio.Key);
//                }
//            }
//        }
//    }
//
//    protected override void OnSystemApplicationFocus(bool focus)
//    {
//        base.OnSystemApplicationFocus(focus);
//
//        if(focus)
//        {
//            GameInterface.Instance.StartCoroutine(Refocus());
//        }
//        else
//        {
//            AudioListener.pause = !focus;
//            foreach (string keyValue in AudioDic.Keys)
//            {
//                AudioDic[keyValue].ResumeAudio(focus);
//            }
//        }
//        Debug.Log("Application Focus " + focus);
//    }

    private IEnumerator Refocus()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        AudioListener.pause = false;
        foreach (string keyValue in AudioDic.Keys)
        {
            AudioDic[keyValue].ResumeAudio(true);
        }
    }

    //protected override void OnSystemLevelWasLoaded(int levelId)
    //{
    //    base.OnSystemLevelWasLoaded(levelId);
    //    ClearAllAudio();
    //}
}
