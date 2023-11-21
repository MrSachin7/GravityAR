using System;
using System.Collections;
using System.Collections.Generic;

public class Planet
{

    public enum PlanetName
    {
        Mercury,
        Venus,
        Earth,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune,

        // Even if they are not planets, we will add them here for simplicity
        Sun,
        Moon
    }


    private PlanetName _planetType;
    public PlanetName PlanetType
    {
        get => _planetType;
        set
        {
            _planetType = value;

            // Set GravityStrength based on PlanetType
            switch (value)
            {
                case PlanetName.Mercury:
                    GravityStrength = 3.7f;
                    break;
                case PlanetName.Venus:
                    GravityStrength = 8.87f;
                    break;
                case PlanetName.Earth:
                    GravityStrength = 9.8f;
                    break;
                case PlanetName.Mars:
                    GravityStrength = 3.711f;
                    break;
                case PlanetName.Jupiter:
                    GravityStrength = 23.1f;
                    break;
                case PlanetName.Saturn:
                    GravityStrength = 9f;
                    break;
                case PlanetName.Uranus:
                    GravityStrength = 8.87f;
                    break;
                case PlanetName.Neptune:
                    GravityStrength = 11f;
                    break;
                // For non-planets like Sun and Moon, you can set their gravity strengths as well
                case PlanetName.Sun:
                    GravityStrength = 274f;
                    break;
                case PlanetName.Moon:
                    GravityStrength = 1.625f;
                    break;
                default:
                    // Handle the case for unknown PlanetType
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PlanetType");
            }
        }
    }
    public float GravityStrength { get; set; }

}
