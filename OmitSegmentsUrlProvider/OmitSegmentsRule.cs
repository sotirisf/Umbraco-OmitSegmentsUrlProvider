namespace DotSee
{
    /// <summary>
    /// A rule for replacing URL segments
    /// </summary>
    public class OmitSegmentsRule
    {
        public string DocTypeAlias { get; set; }
        public string ExcludeDocTypeAliases { get; set; }

        /// <summary>
        /// Creates a new rule for replacing URL segments.
        /// </summary>
        /// <param name="docTypeAlias">The document type alias to look for</param>
        /// <param name="excludeDocTypeAliases">The document type aliases to exclude from URL segments if found in the path of documents of the specified docTypeAlias</param>
        public OmitSegmentsRule(string docTypeAlias, string excludeDocTypeAliases)
        {
            DocTypeAlias = docTypeAlias;
            ExcludeDocTypeAliases = excludeDocTypeAliases;

        }
    }
}
