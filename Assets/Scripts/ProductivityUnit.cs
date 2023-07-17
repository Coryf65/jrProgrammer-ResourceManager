using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    public float ProductivityMultiplier = 2f;
    
    private ResourcePile _currentPile = null;
    
    protected override void BuildingInRange()
    {
        if (_currentPile == null)
        {
            // The notation “as ResourcePile” sets the pile variable to m_Target
            // only if m_Target is a ResourcePile type. If m_Target is a Base,
            // these types won’t match, and pile will be set to null.
            // This is an efficient way of checking whether m_Target is a resource pile.
            ResourcePile pile = m_Target as ResourcePile;
            
            if (pile != null)
            {
                _currentPile = pile;
                _currentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }            
    }
}