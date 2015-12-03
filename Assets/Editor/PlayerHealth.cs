using System;
using NUnit.Framework;

public class PlayerHealth  {
	[Test]
	public void TestHealthStartsAtOne(){
		//PlayerHealth playerHealth = new PlayerHealth ();
		PlayerLives playerHealth = new PlayerLives();
		int expectedHealth = 1;
		int actualHealth = playerHealth.currentHealth1;
		Assert.AreEqual (expectedHealth, actualHealth);
	}
	[Test]
	 public void IgnoredTest()
	 {
		throw new Exception("Ignored this test");
	 }
}
