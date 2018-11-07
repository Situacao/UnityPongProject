using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariablesManager
{
    #region SingletonCenas

    // Referência à própria classe
    private static GlobalVariablesManager instance;

    // Construtor da classe
    public GlobalVariablesManager()
    {
        // Se a instância não for nula, é porque já temos instância
        if (instance != null)
        {
            return;
        }

        // Se não for nula, a instância a usar é esta
        instance = this;
    }

    public static GlobalVariablesManager Instance
    {
        // Get - define que, fora da classe, só podemos ir buscar a sua referência
        get
        {
            // Se não tiver instance, vai inicializar uma nova classe
            if (instance == null)
            {
                instance = new GlobalVariablesManager();
            }

            return instance;
        }
    }

    #endregion

    private int pointsP1;
    public int PointsP1
    {
        get
        {
            return pointsP1;
        }
        set
        {
            pointsP1 = value;
        }
    }

    private int pointsP2;
    public int PointsP2
    {
        get
        {
            return pointsP2;
        }
        set
        {
            pointsP2 = value;
        }
    }
}
