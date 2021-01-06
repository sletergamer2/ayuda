using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Libreria
{
    public static System.Collections.IEnumerator CargarScene(float wait, int scene)
    {
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene(scene);
    }
}
