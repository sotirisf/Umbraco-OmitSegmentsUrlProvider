using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Umbraco.Web;

namespace DotSee
{
    /// <summary>
    /// Loads rules for OmitSegmentsUrlProvider
    /// </summary>
    public sealed class OmitSegmentsRuleManager
    {

        #region Private Members

        /// <summary>
        /// Lazy singleton instance member
        /// </summary>
        private static readonly Lazy<OmitSegmentsRuleManager> _instance = new Lazy<OmitSegmentsRuleManager>(() => new OmitSegmentsRuleManager());

        /// <summary>
        /// The list of rule objects
        /// </summary>
        private List<OmitSegmentsRule> _rules;

        #endregion

        #region Public Members
        
        /// <summary>
        /// Gets the list of rules
        /// </summary>
        public List<OmitSegmentsRule> Rules { get { return _rules; } }
        
        #endregion

        #region Constructors

        /// <summary>
        /// Returns a (singleton) OmitSegmentsRuleManager instance
        /// </summary>
        public static OmitSegmentsRuleManager Instance { get { return _instance.Value; } }

        /// <summary>
        /// Private constructor for Singleton
        /// </summary>
        private OmitSegmentsRuleManager()
        {
            ///This is the prefix web.config keys should have to be included 
            string keyPrefix = "omiturlsegments:";

            _rules = new List<OmitSegmentsRule>();

            //Get all entries with keys starting with specified prefix
            string[] ruleKeys =
                ConfigurationManager.AppSettings.AllKeys
                .Where(x => x.StartsWith(keyPrefix)).ToArray();
             
            //Register a rule for each item
            foreach (string ruleKey in ruleKeys)
            {
                RegisterRule(new OmitSegmentsRule(ruleKey.Replace(keyPrefix, ""), ConfigurationManager.AppSettings[ruleKey]));
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Registers a new rule for url segment replacement
        /// </summary>
        /// <param name="rule">An OmitSegmentsRule object</param>
        public void RegisterRule(OmitSegmentsRule rule)
        {
            _rules.Add(rule);
        }
        
        #endregion  

    }
}
