using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePaint : MonoBehaviour
{
    public UnitySimpleLiquid.LiquidContainer container;
    private void Start()
    {
        UnitySimpleLiquid.LiquidContainer container = gameObject.GetComponent<UnitySimpleLiquid.LiquidContainer>();
    }
    private void FixedUpdate()
    {
        if (container.FillAmountPercent < 0.2)
        {
            if (container.FillAmountPercent < 0.4)
            {
                container.FillAmountPercent += 0.1f * Time.fixedDeltaTime;
            }
        }
    }
}
