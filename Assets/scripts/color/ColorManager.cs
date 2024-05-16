using Unity.VisualScripting;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private ColorRed _redColor;
    [SerializeField] private ColorBlue _blueColor;
    [SerializeField] private ColorWhite _whiteColor;
    [SerializeField] private GameObject projectileRed;
    [SerializeField] private GameObject projectileBlue;
    [SerializeField] private GameObject projectileWhite;
    public KeyCode useColor;
    public KeyCode switchColor;
    public Enums.Types actualType;
    public Rigidbody2D theRB;
    public Transform throwPoint;
    public float projectileSpeed = 5f; // Vitesse de déplacement des projectiles
    public float projectileLifetime = 2f; // Durée de vie des projectiles
    public void UseColor()
    {
        if (Input.GetKeyDown(useColor))
        {
            GameObject projectile = null;

            switch (actualType)
            {
                case Enums.Types.Fire:
                    projectile = Instantiate(projectileRed, transform.position, Quaternion.identity);
                    break;
                case Enums.Types.Water:
                    projectile = Instantiate(projectileBlue, transform.position, Quaternion.identity);
                    break;
                case Enums.Types.Ice:
                    projectile = Instantiate(projectileWhite, transform.position, Quaternion.identity);
                    // Ajoutez ici tout code supplémentaire nécessaire pour le projectile blanc
                    break;
                default:
                    Debug.LogError("Unknown color type!");
                    break;
            }

            if (projectile != null)
            {
                // Ajustez la position de départ du projectile en fonction de vos besoins
                float xOffset = 1f; // Décalage horizontal par rapport à la position actuelle
                float yOffset = 1f; // Décalage vertical par rapport à la position actuelle
                Vector3 startPosition = transform.position + new Vector3(xOffset, yOffset, 0);
                projectile.transform.position = startPosition;

                // Ajustez la vitesse de déplacement en fonction de vos besoins
                float horizontalSpeed = 5f; // Vitesse horizontale du projectile
                projectile.transform.Translate(Vector2.right * horizontalSpeed * Time.deltaTime);

                Destroy(projectile, projectileLifetime);
            }
            else
            {
                Debug.LogError("Failed to instantiate projectile.");
            }
        }
    }

    public void SwitchColor()
    {
        if (Input.GetKeyDown(switchColor))
        {
            if (actualType == Enums.Types.Water)
            {
                actualType = Enums.Types.Ice;
            }
            else if (actualType == Enums.Types.Ice)
            {
                actualType = Enums.Types.Fire;
            }
            else if (actualType == Enums.Types.Fire)
            {
                actualType = Enums.Types.Water;
            }
        }
    }
    private void Start()
    {
        actualType = Enums.Types.Water;
        SwitchColor();
        UseColor();
    }

    private void Update()
    {
        UseColor();
        SwitchColor();
        Debug.Log(actualType);
    }
    private void FixedUpdate()
    {
        SwitchColor();
        UseColor();
    }
}
