using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event7 : MonoBehaviour
{
    public Animator BlackScreen;
    public Camera OsnCamera;

    public GameObject triggerforSheriff, triggerForBerk;

    public string Path_AllInShoke, Path_ToCallSheriff, Path_ToTalkwithBerk;
    public float CamStarthere, Rasstoyanie, speed;

    private int Completing;


    public void EvenT7()
    {

        //Den' 2 - Mat' oret na kuhne i vidit letayushie tarelki

        //Vse v shoke. Mat koekak ugovarivaet nas viiti za sherifom i opisivaet gde on jivet

        if (Completing == 0)
        {
            //Mi idem k sherifu domoi
            //S pomoshyu mislei svoih mi ponimaem gde on jivet
            if (script_for_Events.blackscreen) //zdes triggerforSheriff
            {
                BlackScreen.speed *= 6;
                BlackScreen.SetInteger("ScreenState", 1);
            }
            if (script_for_Events.Special_Watcher)
            {
                OsnCamera.GetComponent<Rigidbody2D>().MovePosition(OsnCamera.transform.position + Vector3.right * Time.deltaTime * speed);
                if (OsnCamera.transform.position.x > CamStarthere + Rasstoyanie)
                {
                    MIxed_dialog.Call_Cutscene_Dialog(Path_AllInShoke);
                    script_for_Events.NeedFreeCamera = false;
                    if (script_for_Events.DialogEnd)
                    {
                        script_for_Events.Trigger_for_SpecWatcher = triggerforSheriff;
                        script_for_Events.DialogEnd = false;
                        Completing++;
                    }
                }
            }
            //sheriffu pohui i on pridet potom sam
        }
        if (Completing == 1)
        {
            if (script_for_Events.Special_Watcher && !script_for_Events.blackscreen)
            {
                MIxed_dialog.Call_Cutscene_Dialog(Path_ToCallSheriff);
                if (script_for_Events.DialogEnd)
                {
                    script_for_Events.Trigger_for_SpecWatcher = triggerForBerk;
                    script_for_Events.DialogEnd = false;
                    Completing++;
                }
            }
            //Okolo doma stoit berk. Mi mojem s nim pogovorit a mojem i net
            //Hans prihodit domoi i vse normalno i mat ubiraet oskolki posudi
            //Esli Hans pogovoril s nim to zadanie budet "prosto viiti k nemu" a esli net to tut nado budet ego iskat

            //V konce koncov on skajet chto agata chto-to nashla i mi posleduem(teleportom) k domu agati za etim
        }
        if (Completing == 2)
        {
            if (script_for_Events.Special_Watcher)
            {
                MIxed_dialog.Call_Cutscene_Dialog(Path_ToTalkwithBerk);
            }
            if (script_for_Events.DialogEnd)
            {
                moving.CantMove = true;
                script_for_Events.DialogEnd = false;
                BlackScreen.SetInteger("ScreenState", 2);
                BlackScreen.speed /= 6;
                Completing++;
            }
            //V dome agati ona rasskazivaet to chto ona nashla na ulice. Eto key kotorii ne podhodit ni k odnomu domu
            //i ni k cerkvi. Etot key tocho ot dveri. Ego dayut Hansu na hranenie potomu chto u jitelei etogo mesta ne prinyato
            //chujie veshi hranit' u sebya. 
            //Tut Berk ne viderjivaet i govorit chto nujno poiti v tot les.
            //Oni idut tuda
        }
        if (Completing == 3)
        {
            //V lokacii lesa oni obnarujivayut medalyon. Na nem napisano chto nekii Edward lyubit Annu
            //Berk govorit chto edvarda zvali tak ego deda no otec nichego takogo pro nego ne rasskazival
            //Berk idet k domu otca a hans ishet eshe shto-to poleznoe no nichego ne nahodit
        }
        if (Completing == 4)
        {
            if (script_for_Events.Special_Watcher)
            {

            }
            //Podoidya k domu berk govorit chto otec nichego ne znaet(hotya na samom dele on skrivaet pis'mo deda) a Hans govorit chto nichego ne nashel
            //Hotya berk uvidel kraem glaza kartu kotoruyu rassmatrival ego otec i v speshke ubral
        }















        //Den' 3 - Rebyata s kartoi nahodyat sunduk v zakoulke lesa

        if (Completing == 0)
        {
            //Hans sprashivaet kak berk smog stashit kartu a on ne hochet govorit ob etom
        }
        if (Completing == 1)
        {
            //V sunduke oni nahodyat stranniy artefakt. oni otlojili ego do luchshih vremen
            //Takje v sunduke bila zapiska kotoraya glasila "(Dumaem nad textom)"
            //Zapisku takje beret hans.
            //Soobschiv o svoei nahodke oni otpravilis k agate
        }
        if (Completing == 2)
        {
            //Agata prochitav zapisku ponimaet cho videla mesto s pohojim opisaniem

        }
        if (Completing == 3)
        {
            //Ona zovet v ee biblioteku. Posle slov o tom chto nachnem poisk nachinaetsya poisk
            //temnii ekran
        }
    }
}
