using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScriptLargeurLongeurAfinir : MonoBehaviour
{
    
    //Script qui va Remplacer Pour que largeur bouge la salle pour pas quelle ce croise. pas fini et pas debugger

    public void modifyDimesion()
    {
        var PanelForDimension = GameObject.Find("panelDimension");
        var original = GameObject.Find(PanelForDimension.transform.Find("NomPiece").GetComponent<TextMeshProUGUI>().text);
        var test = Instantiate(GameObject.Find(PanelForDimension.transform.Find("NomPiece").GetComponent<TextMeshProUGUI>().text));

        foreach (string x in test.GetComponent<CollisionTrigger>().collisionlist)
        {
            Debug.Log(x + "TEST COLLISION LISt ---------------");
        }
        Debug.Log(test.name);

        //string test =(PanelForDimension.transform.Find("NomPiece").GetComponent<TextMeshProUGUI>().text).ToString();
        if (!string.IsNullOrWhiteSpace(PanelForDimension.transform.Find("DonneeLongueur").GetComponentInChildren<TMP_InputField>().text))
        {
            float multiplyScaleLong = float.Parse(PanelForDimension.transform.Find("DonneeLongueur").GetComponentInChildren<TMP_InputField>().text);

            // que pour condition que ya une salle devant, faut faire pareil pour derriere gauche et droite....  haha
            if (!original.GetComponent<CollisionTrigger>().front)
            {
                Debug.Log("----------------rentrer cool if");
                float scalePetit = test.transform.Find("MurAvant").Find("MurD").localScale.x;
                float movex = ((scalePetit * multiplyScaleLong) + 1) / 2;

                // GameObject modifieur sinon le code est litt/rallement 3 fois plus long avec test.transform.find(etc) sur axe des x y et z 
                // Possiblement plus simple si on scale salle au complet, mais largeur des mur axe z vont etre degueux. car on peux pas le scale down apres car le localscale est sur le prefab
                //modif position petit mur arriere ,  avant de scale back dans sa place 
                GameObject modifieur = test.transform.Find("MurAvant").Find("MurD").gameObject;
                modifieur.transform.position = new Vector3(movex, modifieur.transform.position.y, modifieur.transform.position.z);

                modifieur = test.transform.Find("MurAvant").Find("MurG").gameObject;
                modifieur.transform.position = new Vector3(-movex, modifieur.transform.position.y, modifieur.transform.position.z);

                //modif position petit mur arriere ,  avant de scale back dans sa place 
                modifieur = test.transform.Find("MurArriere").Find("MurG").gameObject;
                modifieur.transform.position = new Vector3(movex, modifieur.transform.position.y, modifieur.transform.position.z);

                modifieur = test.transform.Find("MurArriere").Find("MurD").gameObject;
                modifieur.transform.position = new Vector3(-movex, modifieur.transform.position.y, modifieur.transform.position.z);

                //modif scale petite partie mur avant
                modifieur = modifieur.transform.Find("MurD").gameObject;
                modifieur.transform.localScale = new Vector3(scalePetit * multiplyScaleLong, modifieur.transform.localScale.y, modifieur.transform.localScale.z);

                modifieur = test.transform.Find("MurAvant").Find("MurG").gameObject;
                modifieur.transform.localScale = new Vector3(scalePetit * multiplyScaleLong, modifieur.transform.localScale.y, modifieur.transform.localScale.z);

                // modif scale petite partie mur arriere
                modifieur = test.transform.Find("MurArriere").Find("MurG").gameObject;
                modifieur.transform.localScale = new Vector3(scalePetit * multiplyScaleLong, modifieur.transform.localScale.y, modifieur.transform.localScale.z);

                modifieur = test.transform.Find("MurArriere").Find("MurD").gameObject;
                modifieur.transform.localScale = new Vector3(scalePetit * multiplyScaleLong, modifieur.transform.localScale.y, modifieur.transform.localScale.z);

                //Top des murs axe x a scale  
                modifieur = test.transform.Find("MurArriere").Find("MurHaut").gameObject;
                modifieur.transform.localScale = new Vector3((scalePetit * 2) + 1, modifieur.transform.localScale.y, modifieur.transform.localScale.z);

                modifieur = test.transform.Find("MurArriere").Find("MurHaut").gameObject;
                modifieur.transform.localScale = new Vector3((scalePetit * 2) + 1, modifieur.transform.localScale.y, modifieur.transform.localScale.z);

                // Mur axe x a bouger position
                modifieur = test.transform.Find("MurAvant").gameObject;
                modifieur.transform.position = new Vector3(modifieur.transform.Find("MurD").localScale.x / 2, modifieur.transform.position.y, modifieur.transform.position.z);

                modifieur = test.transform.Find("MurArriere").gameObject;
                modifieur.transform.position = new Vector3(modifieur.transform.Find("MurD").localScale.x / 2, modifieur.transform.position.y, modifieur.transform.position.z);

                //Modififer le sol
                modifieur = test.transform.Find("Sol").gameObject;
                modifieur.transform.localScale = new Vector3((modifieur.transform.localScale.x * multiplyScaleLong) + 3, modifieur.transform.localScale.y, modifieur.transform.localScale.z);
                modifieur.transform.position = new Vector3(scalePetit / 2, modifieur.transform.position.y, modifieur.transform.position.z);
                //modifier le seul mur sur axe z 
                modifieur = test.transform.Find("MurDroit").gameObject;
                modifieur.transform.position = new Vector3(modifieur.transform.position.x + test.transform.Find("MurAvant").localScale.x, modifieur.transform.position.y, modifieur.transform.position.z);
            }

            // pour clear list collision en cours si frapper en chemin de salle final
            GameObject test2 = Instantiate(test);
            Destroy(test);

            if (test2.GetComponent<CollisionTrigger>().collisionlist.Count == 0)
            {
                original = test2;
                Destroy(test2);
            }

        }
    }
}
