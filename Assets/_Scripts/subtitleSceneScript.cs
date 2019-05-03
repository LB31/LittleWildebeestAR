using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class subtitleSceneScript : MonoBehaviour
{
    public TextMeshProUGUI tmpUGUI;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(pageOneSequence() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator pageOneSequence() {
        //TMP Box
        tmpUGUI = FindObjectOfType<TextMeshProUGUI>();
        tmpUGUI.fontSize = 12;
        tmpUGUI.color = new Color32(57, 255, 20, 255);

        //Page One Subtitles
        string clearText = "";
        string pageOnePhraseOne = "Ovula nge ina yu uwa via, otuna oku tembuka ka po pehala mha, shaanyhi atu ka sila po kondjala nenota.";
        string pageOnePhraseTwo = "Meme waBenni osho a popi ta nyhongofola, ndele okandjambwena oka uva nyhi ta ti.";
        string pageOnePhraseThree = "Atuyi?, Noutile Benni okwa pukaapuka omakutwi yaye noku vungaula omukati afa ta nyada. ";
        string pageOnePhraseFour = "Oku tembuka pomulonga, mbu wakala eumbo lyaye, nookaume kaye, otaka hupa ngeepi?";
        string pageOnePhraseFive = "Onge ike ovula tayi kaloka!Benni okwa tala keulu.Etango lyo lya ndjena unene,ta li pike evu lya kukuta, ye iha vulu okutala kiikoo.";
        string pageOnePhraseSix = "Omulonga mbu ehole mokuwawa unene , owa pwiinina notau ka kukuta viya. Noinamwenyo mbi ya kala mha, ihayi ka mona mo omeya noikulya.";

        //Page One subtitle Sequence
        tmpUGUI.text = clearText;
        yield return new WaitForSeconds(1);
        // textBox.GetComponent<Text>().text = pageOnePhraseOne;
        tmpUGUI.text =pageOnePhraseOne;
        yield return new WaitForSeconds(3);
        //textBox.GetComponent<Text>().text = clearText;
        tmpUGUI.text = clearText;
        yield return new WaitForSeconds(1);
        //textBox.GetComponent<Text>().text = pageOnePhraseTwo;
        tmpUGUI.text = pageOnePhraseTwo;
        yield return new WaitForSeconds(3);
        tmpUGUI.text = clearText;
        yield return new WaitForSeconds(1);
        tmpUGUI.text = pageOnePhraseThree;
        yield return new WaitForSeconds(3);
        tmpUGUI.text = clearText;
        yield return new WaitForSeconds(1);
        tmpUGUI.text = pageOnePhraseFour;
        yield return new WaitForSeconds(3);
        tmpUGUI.text = clearText;
        yield return new WaitForSeconds(1);
        tmpUGUI.text = pageOnePhraseFive;
        yield return new WaitForSeconds(3);
        tmpUGUI.text = clearText;
        yield return new WaitForSeconds(1);
        tmpUGUI.text = pageOnePhraseSix;
        yield return new WaitForSeconds(3);
        tmpUGUI.text = clearText;
        yield return new WaitForSeconds(1);
    } 
}
