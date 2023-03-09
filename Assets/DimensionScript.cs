using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class DimensionScript : MonoBehaviour
{
    private InputField largeurMur;
    private InputField longeurMur;
    private InputField hauteurMurArriere;
    private InputField hauteurMurAvant;
    private InputField hauteurMurDroit;
    private InputField hauteurMurGauche;
    //will be receive by the name of the button we click
    public GameObject prefabOfSalle;
    public GameObject PanelForDimension;
    public void onClickForDimension()
    {
        
        PanelForDimension.SetActive(true);
        setDimension();

    }

    private void setDimension()
    {
        var prefab = Instantiate(prefabOfSalle);
       // PanelForDimension= prefab.transform.localScale.z.ToString();
        longeurMur.text = prefab.transform.localScale.x.ToString();
        hauteurMurArriere.text = prefab.transform.Find("MurArriere").gameObject.transform.localScale.y.ToString();
        hauteurMurAvant.text = prefab.transform.Find("MurAvant").gameObject.transform.localScale.y.ToString();
        hauteurMurDroit.text = prefab.transform.Find("MurDroit").gameObject.transform.localScale.y.ToString();
        hauteurMurGauche.text = prefab.transform.Find("MurGauche").gameObject.transform.localScale.y.ToString();

    }

}
    // Start is called before the first frame update
 
