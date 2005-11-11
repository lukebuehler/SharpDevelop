// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Drawing;
using System.IO;

using NUnit.Framework;

using ICSharpCode.NRefactory.Parser;
using ICSharpCode.NRefactory.Parser.AST;

namespace ICSharpCode.NRefactory.Tests.AST
{
	[TestFixture]
	public class EventDeclarationTests
	{
		#region C#
		[Test]
		public void CSharpSimpleEventDeclarationTest()
		{
			EventDeclaration ed = ParseUtilCSharp.ParseTypeMember<EventDeclaration>("event System.EventHandler MyEvent;");
			Assert.AreEqual("MyEvent", ed.Name);
			Assert.AreEqual("System.EventHandler", ed.TypeReference.Type);
			
			Assert.IsFalse(ed.HasAddRegion);
			Assert.IsFalse(ed.HasRemoveRegion);
		}
		
		[Test]
		public void CSharpEventImplementingInterfaceDeclarationTest()
		{
			EventDeclaration ed = ParseUtilCSharp.ParseTypeMember<EventDeclaration>("event EventHandler MyInterface.MyEvent;");
			
			Assert.AreEqual("MyEvent", ed.Name);
			Assert.AreEqual("EventHandler", ed.TypeReference.Type);
			
			Assert.IsFalse(ed.HasAddRegion);
			Assert.IsFalse(ed.HasRemoveRegion);
			
			Assert.AreEqual("MyInterface", ed.InterfaceImplementations[0].InterfaceType.Type);
			Assert.AreEqual("MyEvent", ed.InterfaceImplementations[0].MemberName);
		}
		
		[Test]
		public void CSharpEventImplementingGenericInterfaceDeclarationTest()
		{
			EventDeclaration ed = ParseUtilCSharp.ParseTypeMember<EventDeclaration>("event EventHandler MyInterface<string>.MyEvent;");
			
			Assert.AreEqual("MyEvent", ed.Name);
			Assert.AreEqual("EventHandler", ed.TypeReference.Type);
			
			Assert.IsFalse(ed.HasAddRegion);
			Assert.IsFalse(ed.HasRemoveRegion);
			
			Assert.AreEqual("MyInterface", ed.InterfaceImplementations[0].InterfaceType.Type);
			Assert.AreEqual("System.String", ed.InterfaceImplementations[0].InterfaceType.GenericTypes[0].SystemType);
			Assert.AreEqual("MyEvent", ed.InterfaceImplementations[0].MemberName);
		}
		
		[Test]
		public void CSharpAddRemoveEventDeclarationTest()
		{
			EventDeclaration ed = ParseUtilCSharp.ParseTypeMember<EventDeclaration>("event System.EventHandler MyEvent { add { } remove { } }");
			Assert.AreEqual("MyEvent", ed.Name);
			Assert.AreEqual("System.EventHandler", ed.TypeReference.Type);
			
			Assert.IsTrue(ed.HasAddRegion);
			Assert.IsTrue(ed.HasRemoveRegion);
		}
		#endregion
		
		#region VB.NET
		[Test]
		public void VBNetSimpleEventDeclarationTest()
		{
			EventDeclaration ed = ParseUtilVBNet.ParseTypeMember<EventDeclaration>("event MyEvent(x as Integer)");
			Assert.AreEqual(1, ed.Parameters.Count);
			Assert.AreEqual("MyEvent", ed.Name);
			Assert.IsFalse(ed.HasAddRegion);
			Assert.IsFalse(ed.HasRemoveRegion);
		}
		#endregion
	}
}
