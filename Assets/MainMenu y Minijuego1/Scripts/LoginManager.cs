using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class LoginManager : MonoBehaviour
{
    public InputField emailInput;
    public InputField passwordInput;
    public Button loginButton;
    public Text feedbackText; // para mostrar mensajes al usuario

    private string baseURL = "https://localhost:7139/Users/CheckUsrPass"; // Cambia el puerto si usas otro

    void Start()
    {
        loginButton.onClick.AddListener(OnLoginButtonClicked);
    }

    void OnLoginButtonClicked()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            feedbackText.text = "Ingresa correo y contraseña.";
            return;
        }

        StartCoroutine(SendLoginRequest(email, password));
    }

    IEnumerator SendLoginRequest(string email, string password)
    {
        string url = $"{baseURL}/{email}/{password}";
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string response = request.downloadHandler.text;
            Usuarios user = JsonUtility.FromJson<Usuarios>(response);

            if (!string.IsNullOrEmpty(user.correo))
            {
                
                FindFirstObjectByType<GameController>().ActiveMenuPageScene();
                
            }
            else
            {
                feedbackText.text = "Credenciales incorrectas.";
            }
        }
        else
        {
            feedbackText.text = "Error al conectar con el servidor.";
            Debug.LogError(request.error);
        }
    }

    [System.Serializable]
    public class Usuarios
    {
        public int id_usuario;
        public string nombre;
        public string apellido;
        public string correo;
        public string contrasena;
        public int monedas;
        public int experiencia;
        public int puntos;
        public int id_rol;
        public int id_tienda;
    }
}
