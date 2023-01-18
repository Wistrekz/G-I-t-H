using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class TimeLines_script : MonoBehaviour
    {
        public float time;

        Animator animator;

        IEnumerator Start()
        {
            animator = GetComponent<Animator>();
            yield return new WaitForSeconds(time);
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            {
                //скрипт на проверку окончания
            }
        }
    }