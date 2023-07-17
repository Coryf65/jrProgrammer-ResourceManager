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

    private void ResetProductivity()
    {
        if (_currentPile != null)
        {
            _currentPile.ProductionSpeed /= ProductivityMultiplier;
            _currentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target); // run the original method
    }
    
    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
}