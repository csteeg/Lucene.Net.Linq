using Lucene.Net.Documents;

namespace Lucene.Net.Linq.Mapping
{
    /// <see cref="Field.Store"/>
    public enum StoreMode
    {
        /// <see cref="Field.Store.YES"/>
        Yes,// = Field.Store.YES,
        /// <see cref="Field.Store.NO"/>
        No// = Field.Store.NO
    }
    public static class StoreModeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storeMode"></param>
        /// <returns></returns>
        public static Field.Store ToStoreMode(this StoreMode storeMode)
        {
            switch (storeMode)
            {
                case StoreMode.Yes:
                    return Field.Store.YES;
                default:
                    return Field.Store.NO;
            }
        }
    }
}