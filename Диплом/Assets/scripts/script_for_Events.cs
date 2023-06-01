using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class script_for_Events : MonoBehaviour
{
    //Состояние события
    public static bool MissionGoing = true;
    //Имя триггера(Для камеры)
    public static string Triggername;
    //Состояние катсцены
    public static bool Cutscenegoing;
    //Переменаая смотрит за "Triggername"
    public static bool Special_watcher;
    //Состояние чёрного экрана
    public static bool blackscreen = true;
    //Состояние диалога Началось, идёт или кончилось
    public static bool DialogEnd, DialogStart = true, DialogGoing;
    //Номер событий в скриптах событий
    public static int ScriptNumber;
    //Если цель миссии найти предмет
    public static string SearchingItem;
    //Следит за игроком и на какой триггер он наступил
    public static bool Special_Watcher;
    //Тоже следит но при нажатии клавиши
    public static bool Special_Enter_Watcher;
    //Объект для подтверждения триггера
    public static GameObject Trigger_for_SpecWatcher;
    //Тоже объект для подтверждения триггера но с клавиши
    public static GameObject Trigger_for_Enter_SpecWatcher;
    //Показатель состояния эвента
    public static int Completing_static;
    //Свободна камера или нет
    public static bool NeedFreeCamera;
    //переменная для сравнения в FixedUpdate методе
    public static bool CheckCameraInFixedUpd;
    //Переменная для проверки конца анимации
    public static bool AnimateEnd;
    //Для проверки чтения записки
    public static bool ReadsEventNote;
    //Статус мыслей. Началось, идёт или кончилось
    public static bool ThinkEnd, ThinkStart, ThinkGoing;
    //Путь для файла с заданиями
    public static string Path_ToMissions = "Languages_/ru/ru_Events_missions.xml";
    //Количество реплик проигрынных в диалоге
    public static int DialogReplicsNumber;
    //Количество реплик проигрынных в Мыслях
    public static int ThinkReplicNumber;

    public void NextScene(int scene_num)
    {
        SceneManager.LoadScene(scene_num); //Переход на следующую сцену
    }
    public void SetLanguageIn()
    {
        if (!settings_methods.LangSetIn)
        {
            Dictionary_files.Default_lang_settings(); //Установка стандартного языка
        }
    }

    public void Awake()
    {
        Application.targetFrameRate = 60;
    }


    public void AnimationEnd()
    {
        AnimateEnd = true;     //Уведомляет о конце анимации
    }
}
