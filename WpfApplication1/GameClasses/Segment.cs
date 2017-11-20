namespace WpfApplication1.GameClasses
{
    /// <summary>
    /// Отрезок (дороги)
    /// </summary>
    public class Segment
    {
        public Segment()
        {
        }

        public Segment(double offset, double length)
        {
            Offset = offset;
            Length = length;
        }

        /// <summary>
        /// Смещение от 0, м
        /// </summary>
        public double Offset { get; set; }

        /// <summary>
        /// Длина, м
        /// </summary>
        public double Length { get; set; }
    }
}
