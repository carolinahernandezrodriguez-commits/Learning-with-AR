using System;
using System.Text;
using TMPro;
using UnityEngine;

public class WordToGuess : MonoBehaviour
{
    [Header("WordToGuess")]
    public string word;

    [Header("UI")]
    public TMP_InputField field;
    public TMP_Text blanks;

    [Header("Sounds")]
    public AudioSource font;
    public AudioClip correctSound;
    public AudioClip errorSound;

    void Awake()
    {
        field.characterLimit = word.Length;
        field.onValueChanged.AddListener(Actualizar);
        field.onSubmit.AddListener(Comprobar);   // al pulsar Enter / "Hecho" del teclado
    }

    // Se ejecuta cada vez que el panel se activa (al detectar el Model Target)
    void OnEnable()
    {
        field.text = "";
        Actualizar("");
    }

    // Reemplaza guiones por letras de izquierda a derecha.
    // Si se borra una letra, vuelve a aparecer el guion.
    void Actualizar(string escrito)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < word.Length; i++)
        {
            sb.Append(i < escrito.Length ? char.ToUpper(escrito[i]) : '_');
            if (i < word.Length - 1) sb.Append(' ');
        }
        blanks.text = sb.ToString();
    }

    public void Comprobar(string escrito)
    {
        bool acierto = string.Equals(escrito.Trim(), word, StringComparison.OrdinalIgnoreCase);
        font.PlayOneShot(acierto ? correctSound : errorSound);
    }

    // Para enlazar a un botón "Comprobar" (opcional)
    public void ComprobarDesdeBoton()
    {
        Comprobar(field.text);
    }
}