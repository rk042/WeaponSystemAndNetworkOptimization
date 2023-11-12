using System;
using UnityEngine;

namespace ProblemTask1.NetworkUtilites
{
   
    interface INetworkTransform
    {
        public void SendNetworkPosition(Vector3 networkTransform);
        public Vector3 GetPosition { get; }
    }

    public static class Convert
    {
        public static short FloatConvertToShort(this float x)
        {
            if (x < short.MinValue)
            {
                return short.MinValue;
            }
            if (x > short.MaxValue)
            {
                return short.MaxValue;
            }
            return (short)Math.Round(x);
        }
    }
}
