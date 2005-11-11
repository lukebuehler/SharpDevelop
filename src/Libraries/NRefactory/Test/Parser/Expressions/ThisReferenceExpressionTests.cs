﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.IO;
using NUnit.Framework;
using ICSharpCode.NRefactory.Parser;
using ICSharpCode.NRefactory.Parser.AST;

namespace ICSharpCode.NRefactory.Tests.AST
{
	[TestFixture]
	public class ThisReferenceExpressionTests
	{
		#region C#
		[Test]
		public void CSharpThisReferenceExpressionTest1()
		{
			ThisReferenceExpression tre = ParseUtilCSharp.ParseExpression<ThisReferenceExpression>("this");
		}
		#endregion
		
		#region VB.NET
		[Test]
		public void VBNetThisReferenceExpressionTest1()
		{
			ThisReferenceExpression ie = ParseUtilVBNet.ParseExpression<ThisReferenceExpression>("Me");
		}
		#endregion
	}
}
