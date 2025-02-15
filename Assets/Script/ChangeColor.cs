using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color coloreCambio = Color.black;  // Colore che cambierà l'oggetto
    public float tempoPrimaDistruzione = 2f;  // Tempo di attesa prima di applicare il colore
    public float limiteY = -10f;              // Limite Y per determinare la "caduta" dell'oggetto

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica che l'oggetto abbia un Renderer per cambiare colore
        Renderer oggettoRenderer = collision.gameObject.GetComponent<Renderer>();

        // Se l'oggetto ha un Renderer e non è già caduto nel vuoto
        if (oggettoRenderer != null)
        {
            // Avvia una corutina per gestire il cambiamento di colore
            StartCoroutine(CambiaColoreConTimer(collision.gameObject, oggettoRenderer));
        }
    }

    private System.Collections.IEnumerator CambiaColoreConTimer(GameObject oggetto, Renderer oggettoRenderer)
    {
        // Attendere un po' di tempo per vedere se l'oggetto si distrugge
        yield return new WaitForSeconds(tempoPrimaDistruzione);

        // Verifica se l'oggetto è ancora valido e non è caduto troppo in basso
        if (oggetto != null && oggetto.transform.position.y > limiteY)
        {
            // Cambia il colore dell'oggetto
            oggettoRenderer.material.color = Color.black;
        }
    }
}