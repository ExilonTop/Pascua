using System.Collections;
using UnityEngine;
using SceneM = UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [Header("=== NECESSARY ===")]
    public CanvasGroup m_cg;
    public float timeBeforeTransition = 1f;
    public float timeTransition = 2f;

    private void Awake()
    {
        m_cg.alpha = 1;
        StartCoroutine(Transition(m_cg));
    }

    public void ChangeScene(string name) => StartCoroutine(Transition(m_cg, name));
    public void ExitGame() => Application.Quit();

    /// <summary>
    /// Corrutina ! :)
    /// </summary>
    IEnumerator Transition(CanvasGroup m_canvasG, string name = "")
    {
        float initial = m_canvasG.alpha;
        float target = initial == 1 ? 0 : 1;

        yield return new WaitForSeconds(initial == 0 ? timeBeforeTransition : 0);

        for (float i = 0; i < timeTransition; i += Time.deltaTime)
        {
            float t = i / timeTransition;
            m_canvasG.alpha = Mathf.Lerp(initial, target, t);
            yield return null;
        }

        m_canvasG.alpha = target;

        if (string.IsNullOrEmpty(name)) yield break;
        else LoadScene(name);
    }

    /// <summary>
    /// Esta función sirve para cargar una escena desde cualquier lugar.
    /// </summary>
    void LoadScene(string nameScene) => SceneM.SceneManager.LoadScene(nameScene);
}
