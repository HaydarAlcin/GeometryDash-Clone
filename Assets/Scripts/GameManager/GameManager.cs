using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager
{

    public void LoadScene()
    {
        DOTween.Sequence()
               .AppendInterval(1.0f)
               .OnComplete(() =>
               {
                   SceneManager.LoadScene(1);
               });
        
    }

    public void LoadHomeScene()
    {
        SceneManager.LoadScene(0);
    }
}
