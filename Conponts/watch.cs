using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
namespace stopwatch.Conponts
{
    public class watch : MonoBehaviour
    {
        
        public static GameObject playbuttoning = GameObject.Find("watch(Clone)/img/PlayAndPase");
         public  bool started;
         public  bool isplaying;
        Text timeTEXT = null;
      public double time_;
       void Awake()
        {
            timeTEXT = transform.Find("txt/time")?.GetComponent<Text>();
            if (timeTEXT == null)
                Debug.Log("faild to find find Time text Game objict or conpont");
            timeTEXT.fontSize = 21;
        }
        void Start()
        {
            GameObject hand = GameObject.Find("OfflineVRRig/Actual Gorilla/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/"); 
            base.transform.SetParent(hand.transform, false);
            base.transform.localPosition = new Vector3(0.0054f, 0.0784f, 0.0011f);
            //287.1203f, 275.7359f, 2.9292f,

            //359.9633f, 185.754f, 73.7938f,
            //0.7934f, 0.8934f, 0.7934f

            //353.4537f, 184.494f, 74.6988f,
            //350.5857f, 169.4878f, 73.3021f,

            //66.8306f, 91.4948f, 90f,
            //base.transform.rotation = new Quaternion(317.8279f, 182.0492f, 69.3005f, -50f);
            base.transform.localScale = new Vector3(0.7934f, 0.8934f, 0.7934f);

        }
        void Update()
        {
            
            if(started && isplaying)
            {
                time_ += (double)Time.deltaTime;
            }
            TimeSpan timeSpan = TimeSpan.FromSeconds(time_);
            timeTEXT.text = $"{timeSpan.Hours}:{timeSpan.Minutes}:{timeSpan.Seconds}.{timeSpan.Milliseconds}";







        }
    }
}
