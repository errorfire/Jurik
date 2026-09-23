using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.StickyNote;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer1 = Color.white;
    public Color colorPlayer2 = Color.white;
    public string namePlayer1;
    public string namePlayer2;
    public string GetName(bool isPlayer1)
    {
        return isPlayer1 ? namePlayer1 : namePlayer2;
    }
    void Start()
    {
        SaveController.Instance.Reset();
    }

    private static SaveController _instance;
    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<SaveController>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString("SavedWinner", winner);
    }
    public string GetLastWinner()
    {
        return PlayerPrefs.GetString("SavedWinner");
    }
    public void Reset()
    {
        namePlayer1 = "";
        namePlayer1 = "";
        colorPlayer2 = Color.white;
        colorPlayer1 = Color.white;
    }
    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
