using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Tile
{
    public Vector2 Pos;
    public List<GridBased> Objects;

    public Tile(int posX, int posY)
    {
        Pos = new Vector2(posX, posY);
        Objects = new List<GridBased>();
    }

    public Tile(Vector2 pos)
    {
        Pos = pos;
        Objects = new List<GridBased>();
    }
}

public class GridManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] bool m_debugMode = false;
    [SerializeField] GameObject m_debugTileRepresentation = null;

    [Header("Setup")]
    [SerializeField] float m_spacing;
    [SerializeField] int m_width, m_height;    
    [SerializeField] Vector2 m_startPosition;

    [HideInInspector] public static GridManager Instance;

    Tile[][] m_tileMatrix;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        m_tileMatrix = new Tile[m_width][];

        for (int i = 0; i < m_width; i++)
        {
            m_tileMatrix[i] = new Tile[m_height];

            for (int j = 0; j < m_height; j++)
            {
                Vector2 pos = new Vector2(i, j);

                Tile tile = new Tile(pos);
                m_tileMatrix[i][j] = tile;

                Vector2 worldPos = pos * m_spacing + m_startPosition;

                if (m_debugMode && m_debugTileRepresentation != null)
                    Instantiate(m_debugTileRepresentation, worldPos, Quaternion.identity);
            }
        }
    }

    void Update()
    {
        
    }

    public Vector2 GridIndexToWorldPosition(Vector2 pos)
    {
        Vector2 resultPos = pos;
        resultPos.x = Mathf.Round(resultPos.x / m_spacing);
        resultPos.y = Mathf.Round(resultPos.y / m_spacing);
        return resultPos;
    }

    public Vector2 WorldPositionToGridIndex(Vector2 pos)
    {
        throw new System.NotImplementedException();
    }

    public Vector2 FitToWorld(Vector2 pos)
    {
        Vector2 resultPos = pos;

        resultPos.x = Mathf.Floor((resultPos.x - m_startPosition.x) / m_spacing) * m_spacing + m_startPosition.x;
        resultPos.x = Mathf.Clamp(resultPos.x, m_startPosition.x, m_startPosition.x + m_width);

        resultPos.y = Mathf.Floor((resultPos.y - m_startPosition.y) / m_spacing) * m_spacing + m_startPosition.y;        
        resultPos.y = Mathf.Clamp(resultPos.y, m_startPosition.y, m_startPosition.y + m_height);

        return resultPos;
    }

    public List<GridBased> PeekTileGrid(Vector2 pos)
    {
        return m_tileMatrix[(int)pos.x][(int)pos.y].Objects;
    }

    public List<GridBased> PeekTileWorld(Vector2 pos)
    {
        Vector2 gridPos = WorldPositionToGridIndex(pos);
        return PeekTileGrid(gridPos);
    }
}
