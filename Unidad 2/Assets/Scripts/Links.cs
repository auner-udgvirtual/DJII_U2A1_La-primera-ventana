using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Links : MonoBehaviour
{

    public void OpenUDG() {
        Debug.Log("Opening link!");
        Application.OpenURL("https://www.udg.mx/en/welcome-university-guadalajara");
    }
    public void OpenUDGVirtual() {
        Debug.Log("Opening link!");
        Application.OpenURL("http://www.udgvirtual.udg.mx/");
    }
    public void OpenGoogle() {
        Debug.Log("Opening link!");
        Application.OpenURL("https://www.google.com/");
    }

}
