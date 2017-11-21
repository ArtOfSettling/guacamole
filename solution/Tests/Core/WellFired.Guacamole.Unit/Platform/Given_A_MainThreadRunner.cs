﻿using System;
using NUnit.Framework;
using WellFired.Guacamole.Platform;

namespace WellFired.Guacamole.Unit.Platform
{
	[TestFixture]
	public class Given_A_MainThreadRunner
	{
		[Test]
		public void When_ProcessAction_Then_ActionsAreExecuted_InRightOrder()
		{
			var actionResult = 0f;
			
			var mainThreadRunner = new MainThreadRunner();
			var action1 = new Action(() => actionResult = 3);
			var action2 = new Action(() => actionResult *= 2f);
			var action3 = new Action(() => actionResult -= 0.5f);
			MainThreadRunner.ExecuteOnMainThread(action1);
			MainThreadRunner.ExecuteOnMainThread(action2);
			MainThreadRunner.ExecuteOnMainThread(action3);

			mainThreadRunner.ProcessActions();
			
			Assert.AreEqual(5.5f, actionResult);
		}
		
		[Test]
		public void When_ProcessAction_Then_ActionsAreExecuted_And_Removed()
		{
			var actionResult = 0f;
			
			var mainThreadRunner = new MainThreadRunner();
			var action1 = new Action(() => actionResult = 3);
			var action2 = new Action(() => actionResult *= 2f);
			var action3 = new Action(() => actionResult -= 0.5f);
			MainThreadRunner.ExecuteOnMainThread(action1);
			MainThreadRunner.ExecuteOnMainThread(action2);
			MainThreadRunner.ExecuteOnMainThread(action3);

			mainThreadRunner.ProcessActions();
			Assert.AreEqual(5.5f, actionResult);
			
			mainThreadRunner.ProcessActions();
			Assert.AreEqual(5.5f, actionResult);
		}
	}
}