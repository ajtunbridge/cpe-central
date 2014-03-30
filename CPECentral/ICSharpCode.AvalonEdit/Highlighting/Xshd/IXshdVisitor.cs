#region Using directives

using System.Diagnostics.CodeAnalysis;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting.Xshd
{
    /// <summary>
    ///     A visitor over the XSHD element tree.
    /// </summary>
    public interface IXshdVisitor
    {
        /// <summary />
        object VisitRuleSet(XshdRuleSet ruleSet);

        /// <summary />
        object VisitColor(XshdColor color);

        /// <summary />
        object VisitKeywords(XshdKeywords keywords);

        /// <summary />
        object VisitSpan(XshdSpan span);

        /// <summary />
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords",
            Justification = "A VB programmer implementing a visitor?")]
        object VisitImport(XshdImport import);

        /// <summary />
        object VisitRule(XshdRule rule);
    }
}