using Lucene.Net.Documents;

namespace Lucene.Net.Linq.Mapping
{
    /// <see cref="Field.Index"/>
    public enum IndexMode
    {
        /// <see cref="Field.Index.NO"/>
        NotIndexed,// = Field.Index.NO,
        /// <see cref="Field.Index.ANALYZED"/>
        Analyzed,// = Field.Index.ANALYZED,
        /// <see cref="Field.Index.ANALYZED_NO_NORMS"/>
        AnalyzedNoNorms,// = Field.Index.ANALYZED_NO_NORMS,
        /// <see cref="Field.Index.NOT_ANALYZED"/>
        NotAnalyzed,// = Field.Index.NOT_ANALYZED,
        /// <see cref="Field.Index.NOT_ANALYZED_NO_NORMS"/>
        NotAnalyzedNoNorms// = Field.Index.NOT_ANALYZED_NO_NORMS,
    }

    public static class IndexModeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="indexMode"></param>
        /// <returns></returns>
        public static Field.Index ToFieldIndex(this IndexMode indexMode)
        {
            switch (indexMode)
            {
                case IndexMode.Analyzed:
                    return Field.Index.ANALYZED;
                case IndexMode.AnalyzedNoNorms:
                    return Field.Index.ANALYZED_NO_NORMS;
                case IndexMode.NotAnalyzed:
                    return Field.Index.NOT_ANALYZED;
                case IndexMode.NotAnalyzedNoNorms:
                    return Field.Index.NOT_ANALYZED_NO_NORMS;
                default:
                    return Field.Index.NO;
            }
        }
    }
}