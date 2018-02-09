using LinqToQueryString.Parsing;

namespace LinqToQueryString
{
    public class CollectionResourceQueryModel
    {
        public ResultOperator? ResultOperator { get; internal set; }
        public bool ResultDefaultIfEmpty { get; set; } = false;
    }
}