
namespace ProblemTask1.Network
{
    [System.Serializable]
    public struct NetworkTransformPosition
    {
        public short x { get; set; }
        public short y { get; set; }
        public short z { get; set; }

        public NetworkTransformPosition(short x, short y, short z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"x: {x} y: {y} z:{z}";
        }
    }
}
