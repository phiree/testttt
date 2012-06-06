using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intelligencia.UrlRewriter;
using System.Xml;
using System.Web;
using System.IO;
namespace BLL.SEO
{
    public class RewriteConditioncs : IRewriteCondition
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="location"></param>
        public RewriteConditioncs(string location)
        {
            _location = location;
        }

        /// <summary>
        /// Determines if the condition is matched.
        /// </summary>
        /// <param name="context">The rewriting context.</param>
        /// <returns>True if the condition is met.</returns>
        public bool IsMatch(RewriteContext context)
        {
            string filename = HttpContext.Current.Server. MapPath(context.Expand(_location));
            return File.Exists(filename) || Directory.Exists(filename);
        }

        private string _location;
    }
    public class RewriteConditionParser : IRewriteConditionParser
    {

        public IRewriteCondition Parse(XmlNode node)
        {
            XmlNode existsAttr = node.Attributes.
            GetNamedItem("mycondition");


            if (existsAttr != null)
            {
                var conditionName = existsAttr.Value;
                if (conditionName == "homepage")
                {
                    return new RewriteConditioncs("/");
                }

                
            }

            return null;
        }
    }

}
