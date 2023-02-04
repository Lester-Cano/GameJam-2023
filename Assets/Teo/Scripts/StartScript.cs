using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScript : MonoBehaviour
{
 public void GoToScene(string sceneName){
      SceneManager.LoadScene(sceneName);
 }
}
