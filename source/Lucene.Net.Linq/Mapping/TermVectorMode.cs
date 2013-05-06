using Lucene.Net.Documents;

namespace Lucene.Net.Linq.Mapping
{
    /// <see cref="Field.TermVector"/>
    public enum TermVectorMode
    {
        No,// = Field.TermVector.NO,
        Yes,// = Field.TermVector.YES,
        WithOffsets,// = Field.TermVector.WITH_OFFSETS,
        WithPositions,// = Field.TermVector.WITH_POSITIONS,
        WithPositionsAndOffsets// = Field.TermVector.WITH_POSITIONS_OFFSETS
    }

    public static class TermVectorModeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="termVector"></param>
        /// <returns></returns>
        public static Field.TermVector ToTermVector(this TermVectorMode termVector)
        {
            switch (termVector)
            {
                case TermVectorMode.Yes:
                    return Field.TermVector.YES;
                case TermVectorMode.WithOffsets:
                    return Field.TermVector.WITH_OFFSETS;
                case TermVectorMode.WithPositions:
                    return Field.TermVector.WITH_POSITIONS;
                case TermVectorMode.WithPositionsAndOffsets:
                    return Field.TermVector.WITH_POSITIONS_OFFSETS;
                default:
                    return Field.TermVector.NO;
            }
        }
    }
}