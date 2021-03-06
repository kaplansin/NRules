﻿using System.Collections.Generic;
using System.Linq.Expressions;

namespace NRules.RuleModel
{
    /// <summary>
    /// Pattern condition element.
    /// </summary>
    public class ConditionElement : RuleElement
    {
        private readonly List<Declaration> _declarations;

        /// <summary>
        /// Expression that represents a boolean condition.
        /// </summary>
        public LambdaExpression Expression { get; set; }

        /// <summary>
        /// List of declarations the condition expression references.
        /// </summary>
        public IEnumerable<Declaration> Declarations
        {
            get { return _declarations; }
        }

        internal ConditionElement(IEnumerable<Declaration> declarations, LambdaExpression expression)
        {
            _declarations = new List<Declaration>(declarations);
            Expression = expression;
        }

        internal override void Accept<TContext>(TContext context, RuleElementVisitor<TContext> visitor)
        {
            visitor.VisitCondition(context, this);
        }
    }
}