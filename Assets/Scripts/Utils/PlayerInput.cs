﻿using System;
using UnityEngine;

public class PlayerInput 
{
    public event Action<Vector3> MoveDirChanged;
    public PlayerInput(float movementChange) => m_movementChange = movementChange;

    private readonly float m_movementChange;
    
    private float m_x;
    private float m_y;

    public void RestartMoveDir()
    {
        m_x = 0;
        m_y = 0;
        MoveDirChanged?.Invoke(Vector3.zero);
    }
    
    public Vector3 Update(Vector3 moveDir)
    {
        m_x = Horizontal(m_x);
        m_y = Vertical(m_y);
        
        var dir = new Vector3(m_x, 0, m_y);
        
        if (dir != moveDir)
            MoveDirChanged?.Invoke(dir);

        return dir;
    }
    
    private float Vertical(float y)
    {
        if (Input.GetKey(KeyCode.S))
            y -= m_movementChange * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
            y += m_movementChange * Time.deltaTime;
        
        return y;
    }

    private float Horizontal(float x)
    {
        if (Input.GetKey(KeyCode.A))
            x -= m_movementChange * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            x += m_movementChange * Time.deltaTime;
        
        return x;
    }
}