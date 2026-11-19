using System;
using System.Text;
using TMPro;
using UnityEngine;

public class WordToGuess : MonoBehaviour
{
    [Header("Palabra a adivinar")]
    public string palabra = "gato";

    [Header("UI")]
    public TMP_InputField campo;
    public TMP_Text textoGuiones;

    [Header("Sonidos")]
    public AudioSource fuente;
    public AudioClip sonidoCorrecto;
    public AudioClip sonidoError;

    void Awake()
    {
        campo.characterLimit = palabra.Length;
        campo.onValueChanged.AddListener(Actualizar);
        campo.onSubmit.AddListener(Comprobar);
    }

    void OnEnable()
    {
        campo.text = "";
        Actualizar("");
    }

    // Reemplaza guiones por letras de izquierda a derecha.
    // Si se borra una letra, vuelve a aparecer el guion.
    void Actualizar(string escrito)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < palabra.Length; i++)
        {
            sb.Append(i < escrito.Length ? char.ToUpper(escrito[i]) : '_');
            if (i < palabra.Length - 1) sb.Append(' ');
        }
        textoGuiones.text = sb.ToString();
    }

    public void Comprobar(string escrito)
    {
        bool acierto = string.Equals(escrito.Trim(), palabra, StringComparison.OrdinalIgnoreCase);
        fuente.PlayOneShot(acierto ? sonidoCorrecto : sonidoError);
    }

    public void ComprobarDesdeBoton()
    {
        Comprobar(campo.text);
    }
}