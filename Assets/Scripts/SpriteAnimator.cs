using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [System.Serializable]
    public class Animation
    {
        public string name;
        public float fps;
        public string customFrameSequence;
        public bool loop = true;
        public Sprite[] frames;
        

        

        [HideInInspector]
        public int length { get; set; }
        [HideInInspector]
        public List<int> frameOrder;
    }
    
    public string playOnStart;

    [HideInInspector]
    public float speedMultiplier = 1f;

    public SpriteRenderer spriteRenderer;
    public Animation[] animations;

    private Dictionary<string, Animation> animationDictionary;

    public bool isPlaying { get; private set; }
    public Animation currentAnimation { get; private set; }
    public int currentFrame { get; private set; }
    

    private float timer;
    private float delay;


    
    void Awake()
    {
        PrepareAnimations();

        

        if(spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        if(playOnStart != "")
        {
            Play(playOnStart);
        }
    }

    private void Update()
    {
        if (isPlaying)
        {
            UpdateAnimation();
        }
    }

    void PrepareAnimations()
    {
        animationDictionary = new Dictionary<string, Animation>();
        foreach (Animation animation in animations)
        {
            animationDictionary.Add(animation.name, animation);


            if (animation.customFrameSequence != null && animation.customFrameSequence != "")
            {
                
                string[] split = animation.customFrameSequence.Split(',');

                for (int i = 0; i < split.Length; i++)
                {
                    string data = split[i];
                    string[] databits = data.Split('-');

                    if(databits.Length > 1)
                    {
                        int startFrame = int.Parse(databits[0].Trim());
                        int endFrame = int.Parse(databits[1].Trim());
                        for (int j = startFrame; j <= endFrame; j++)
                        {
                            animation.frameOrder.Add(j);
                        }
                        
                    }
                    else
                    {
                        if (databits[0] != "")
                        {
                            animation.frameOrder.Add(int.Parse(databits[0].Trim()));
                        }
                    }
                }

                /*
                Debug.Log(animation.name);
                Debug.Log("count: " + animation.frameOrder.Count.ToString());
                string order = "";
                for (int i = 0; i < animation.frameOrder.Count; i++)
                {
                    order = order + "," + animation.frameOrder[i];
                }
                order = order.Substring(1);
                Debug.Log(order);
                */
            }
            else
            {
                for(int i = 0; i < animation.frames.Length; i++)
                {
                    animation.frameOrder.Add(i);
                }
            }
        }
    }

    public void Play(string name, int startingFrame = 0)
    {
        // If animation is already playing, do nothing. Otherwise, start the animation.
        Animation animation = GetAnimation(name);
        if (animation != null)
        {
            if(animation != currentAnimation)
            {
                ForcePlay(name, startingFrame);
            }
        }

    }

    public void ForcePlay(string name, int startingFrame = 0)
    {
        // Start the animation from its first frame.
        Animation animation = GetAnimation(name);
        if (animation != null)
        {
            currentAnimation = animation;
            timer = 0f;
            delay = 1f / (float)animation.fps;
            if (startingFrame < animation.frames.Length)
            {
                currentFrame = startingFrame;
            }
            else
            {
                currentFrame = 0;
            }
            UpdateAnimation();
            isPlaying = true;
        }

    }

    public void Stop()
    {
        isPlaying = false;
    }

    public void ClearAnimation()
    {
        Stop();
        currentAnimation = null;
    }

    public bool IsPlayingClip(string name)
    {
        return (currentAnimation != null && currentAnimation.name == name);
    }

    Animation GetAnimation(string name)
    {
        if (animationDictionary.ContainsKey(name))
        {
            return animationDictionary[name];
        }
        else
        {
            Debug.LogError("Animation \"" + name + "\" not found on " + gameObject.name);
            return null;
        }
    }

    void UpdateAnimation()
    {
        spriteRenderer.sprite = currentAnimation.frames[currentAnimation.frameOrder[currentFrame]];

        if (timer >= delay)
        {
            timer -= delay;
            NextFrame();
        }
        else
        {
            timer += Time.deltaTime * speedMultiplier;
        }
    }

    void NextFrame()
    {
        currentFrame++;

        if (currentFrame == currentAnimation.frameOrder.Count)
        {
            if (currentAnimation.loop)
            {
                currentFrame = 0;
            }
            else
            {
                currentFrame = currentAnimation.frameOrder.Count - 1;
                Stop();
            }
        }
    }

    public int GetFacing()
    {
        return (int)Mathf.Sign(spriteRenderer.transform.localScale.x);
    }

    public void FlipTo(float dir)
    {
        if (dir < 0f)
        {
            spriteRenderer.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            spriteRenderer.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void FlipTo(Vector3 position)
    {
        float diff = position.x - transform.position.x;

        if(diff < 0f)
        {
            spriteRenderer.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            spriteRenderer.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
