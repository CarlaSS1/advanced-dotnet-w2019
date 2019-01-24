/*
 * Copyright 2016-2019 Mohawk College of Applied Arts and Technology
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you 
 * may not use this file except in compliance with the License. You may 
 * obtain a copy of the License at 
 * 
 * http://www.apache.org/licenses/LICENSE-2.0 
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations under 
 * the License.
 * 
 * User: Nityan Khanna
 * Date: 2019-1-24
 */
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Week3ExpressionVisitor
{
	public class Program
	{
		private static void Main(string[] args)
		{
			Expression<Func<string, bool>> myExpression = (x) => x != null && x.Length > 5 && x.StartsWith("A");

			Console.WriteLine($"Before re-writing: {myExpression}");

			MyExpressionVisitor expressionVisitor = new MyExpressionVisitor();

			var resultExpression = expressionVisitor.Visit(myExpression);

			Console.WriteLine($"After re-writing: {resultExpression}");

			Expression<Func<int, int, int, double>> myOtherExpression = (x, y, z) => x + y * z;

			Console.WriteLine($"Before re-writing: {myOtherExpression}");

			var otherResultExpression = expressionVisitor.Visit(myOtherExpression);

			Console.WriteLine($"After re-writing: {otherResultExpression}");

			Console.ReadKey();
		}
	}

	public class MyExpressionVisitor : ExpressionVisitor
	{
		public override Expression Visit(Expression node)
		{
			// apply a switch case to the node of the expression
			switch (node.NodeType)
			{
				// if the expression is and, or, and also, or else
				// we want to visit the binary expression
				case ExpressionType.And:
				case ExpressionType.AndAlso:
				case ExpressionType.Or:
				case ExpressionType.OrElse:
					return this.VisitBinary((BinaryExpression)node);
				// if the expression is constant
				// visit the constant expression
				case ExpressionType.Constant:
					return this.VisitConstant((ConstantExpression)node);
				default:
					return base.Visit(node);
			}
		}

		protected override Expression VisitBinary(BinaryExpression node)
		{
			// apply a switch case to the node type of the binary expression
			switch (node.NodeType)
			{
				// if the type is and, and also, or, or else
				// we want to change the binary expression
				case ExpressionType.And:
				case ExpressionType.AndAlso:
				case ExpressionType.Or:
				case ExpressionType.OrElse:
					// because expressions are immutable
					// we need to visit the left and right side of the each node in the tree
					// for the given expression, which will yield the left and right side of the expression
					var right = this.Visit(node.Right);
					var left = this.Visit(node.Left);

					// we want re-write the expression to be an "or else" binary expression
					return Expression.MakeBinary(ExpressionType.OrElse, left, right);
				case ExpressionType.Add:
				case ExpressionType.Multiply:
					// visit the left side
					var l = this.Visit(node.Left);
					// visit the right side
					var r = this.Visit(node.Right);

					// re-write all the expression types to subtract
					// if we find the expression type as add or multiply
					return Expression.MakeBinary(ExpressionType.Subtract, l, r);
			}

			// return all other types of expressions normally
			// as we do not want to change any other type of expression in our expression tree
			return base.VisitBinary(node);
		}

		protected override Expression VisitConstant(ConstantExpression node)
		{
			return base.VisitConstant(node);
		}
	}
}
