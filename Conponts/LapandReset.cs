using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace stopwatch.Conponts
{
    enum  Mode { Lap, Reset, off }
    internal class LapandReset : HandTrigger
    {
      public static Mode mode;
        public bool isplaying;
        public bool started;
        public watch watch;
        public StartAndstop andstop;
        public static GameObject obj;
        double laptime;
        Text laptext;
     public static Text laptextonbutn;
        protected override void Awake()
        {
            obj = this.gameObject;
            mode = Mode.off;
            watch = GameObject.Find("watch(Clone)")?.GetComponent<watch>();
            if (watch == null) { Debug.Log("coude not find watch parnt or conpnte"); }
            laptext = GameObject.Find("watch(Clone)/txt/Lap text")?.GetComponent<Text>();
            if (laptext == null) { Debug.Log("couse not find lap text or conptnt"); }
            laptextonbutn = GameObject.Find("watch(Clone)/txt/laptext")?.GetComponent<Text>();
            if (laptextonbutn == null) { Debug.Log("couse not find text or conptnt"); }
            andstop = GameObject.Find("watch(Clone)/bnt/play")?.GetComponent<StartAndstop>();
            if (andstop == null) { Debug.Log("couse not find startandstop script or obkict"); }
        }
        protected override void HandTriggered()
        {
           
            if(mode == Mode.Lap)
            {
                Lap();
            }
            if(mode == Mode.Reset)
            {
                
                Reset();
            }
            
        }
        void Lap()
        {
            laptime = watch.time_;
            TimeSpan timeSpan = TimeSpan.FromSeconds(laptime);
            laptext.text = $"{timeSpan.Hours}:{timeSpan.Minutes}:{timeSpan.Seconds}.{timeSpan.Milliseconds}";

        }
      void Reset()
        {
            mode = Mode.off;
            laptext.text = "00:00:00.00";
            laptextonbutn.text = "Lap";
            gameObject.GetComponent<MeshRenderer>().material.color = new Color32(24, 24, 24, 100);
            watch.time_ = 0;
            andstop.started = false;
            andstop.isplaying = false;
            andstop.Updatevisules();
        }
       
    }
}