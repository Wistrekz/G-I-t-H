using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSourcing : MonoBehaviour
{
    public bool IsSmooth;
    public bool IsNeedSkipInsong;
    public float timeforskip;
    public float timing;

    private void Update()
    {
        if(SceneManager.sceneCount == 0)
        {
            Audio_On(true, gameObject.GetComponent<AudioSource>(), timing, timeforskip); //В стартовом менюмузыка играет сразу а в остальных сценах по вызову
        }
    }

    public void Audio_On(bool smoothOrNot, AudioSource audio, float timeawait, float timeforskip)
    {
        if(smoothOrNot) //Плавно запустить звук или нет
        {
            if(IsNeedSkipInsong) //Какую часть нужно ли пропустить
            {
                audio.volume = 0;
                audio.Play(); //Проигрыш
                StartCoroutine(AwaiterEvent1(timeforskip)); //Пропускаем часть
                for (int i = 0; i < 355; i++)
                {
                    audio.volume += (float)0.001;
                    StartCoroutine(AwaiterEvent1(timeawait)); //Пропускаем время чтобы было плавно
                }
            }
            else
            {
                audio.volume = 0;
                audio.Play();
                for (int i = 0; i < 355; i++)
                {
                    audio.volume += (float)0.001;
                    StartCoroutine(AwaiterEvent1(timeawait));//Пропускаем время чтобы было плавно
                }
            }
        }
        else 
        {
            audio.Play(); //Проигрыш
        }
    }

    public void Audio_Off(bool smoothOrNot, AudioSource audio, float timeawait)
    {
        if (smoothOrNot)
        {
            audio.volume = 0;
            for (int i = 0; i < 355; i++)
            {
                audio.volume += (float)0.001;
                StartCoroutine(AwaiterEvent1(timeawait));
            }
            audio.Stop(); //Выключение
        }
        else
        {
            audio.Stop();
        }
    }

    IEnumerator AwaiterEvent1(float timewait)
    {
        yield return new WaitForSeconds(timewait);
    }
}
