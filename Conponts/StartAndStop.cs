using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;
using System.Reflection;
using UnityEngine.UI;
namespace stopwatch.Conponts
{
    internal class StartAndstop : HandTrigger
    {
      
       public bool isplaying;
       public bool started;
        public watch watch;
        Image imgplay;
    protected override void Awake()
        {
            /* not working rn Friday, June 17, 2022 at 12:11am */
            imgplay = GameObject.Find("watch(Clone)/img/PlayAndPase")?.GetComponent<Image>();
            if (imgplay == null)
                Debug.Log("No play pase imige was found");
            watch = GameObject.Find("watch(Clone)")?.GetComponent<watch>();
            if (watch == null) { Debug.Log("coude not find watch parnt or conpnte"); }
                
        }

        /* Play */
        #region
        protected override void HandTriggered()
        {

            isplaying = !isplaying;
            Updatevisules();
           

        }
        void Update()
        {
            watch.isplaying = isplaying;
            watch.started = started;

        }
        void FixedUpdate()
        {
           
        }
        public void Updatevisules()
        {
            if (isplaying)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                imgplay.sprite = Plugin.paseimg;
                if (started == false)
                {
                    started = true;

                }
                LapandReset.mode = Mode.Lap;
                LapandReset.obj.GetComponent<MeshRenderer>().material.color = Color.gray;
            }
            if (!isplaying && started)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                imgplay.sprite = Plugin.playimg;
                LapandReset.mode = Mode.Reset;
                LapandReset.obj.GetComponent<MeshRenderer>().material.color = Color.red;
                LapandReset.laptextonbutn.text = "Reset";
                //Viseluses here
            }
        }
        
        /*if (collider.name == "play")
        {
            if(started)
            {
               
                if (!isplaying)
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                } else
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                }
            } else
            {
                started = true;
                isplaying = true;
                gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            #endregion
        }*/
        #endregion




    }


}

