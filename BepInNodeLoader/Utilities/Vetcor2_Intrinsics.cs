namespace System.Numerics
{
    public partial struct Vector2
    {
        /// <summary>
        /// The X component of the vector.
        /// </summary>
        public Single X;
        /// <summary>
        /// The Y component of the vector.
        /// </summary>
        public Single Y;

        #region Constructors
        /// <summary>
        /// Constructs a vector whose elements are all the single specified value.
        /// </summary>
        /// <param name="value">The element to fill the vector with.</param>
        public Vector2(Single value) : this(value, value) { }

        /// <summary>
        /// Constructs a vector with the given individual elements.
        /// </summary>
        /// <param name="x">The X component.</param>
        /// <param name="y">The Y component.</param>
        public Vector2(Single x, Single y)
        {
            X = x;
            Y = y;
        }
        #endregion Constructors
    }
}
