using UnityEngine;
using TMPro;
public class PontuationScript : MonoBehaviour
{
    public PlayerScript p;
    public TextMeshProUGUI pontuation;

    // Update is called once per frame
    void Update()
    {
        pontuation.text = p.points.ToString();
    }
}
