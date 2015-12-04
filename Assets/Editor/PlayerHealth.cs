using System;
using NUnit.Framework;
/// <summary>
/// Player health. Piotr Test
/// </summary>
public class PlayerHealth  {
	
/// <summary>
/// Tests the health starts at three player1.
/// </summary>
	[Test]
	public void TestHealthStartsAtThreePlayer1(){
		PlayerLives playerLives = new PlayerLives ();
		int expectedHealth = 3;
		int actualHealth = playerLives.currentHealth1;
		Assert.AreEqual (expectedHealth, actualHealth);
	}
	/// <summary>
	/// Tests the health starts at three player2.
	/// </summary>
	[Test]
	public void TestHealthStartsAtThreePlayer2(){
		PlayerLives playerLives = new PlayerLives ();
		int expectedHealth = 3;
		int actualHealth = playerLives.currentHealth2;
		Assert.AreEqual (expectedHealth, actualHealth);
	}

	/// <summary>
	/// Tests the health after damage player2 old method. Compiler error, void method instead of return.
	/// </summary>
	/*[Test]
	public void TestHealthAfterDamagePlayer2OldMethod(){
		PlayerLives playerLives = new PlayerLives ();
		int expectedHealth = 0;
		int actualHealth = playerLives.currentHealth2;

		actualHealth = actualHealth - playerLives.WrongAnswer("Player1");
		Assert.AreEqual (expectedHealth, actualHealth);
	}*/

	/// <summary>
	/// Tests the health after damage player2. I created new method in PlayerLives() to cut the health
	/// </summary>
	[Test]
	public void TestHealthAfterDamagePlayer1(){
		PlayerLives playerLives = new PlayerLives ();
		int expectedHealth = 0;
		int actualHealth = playerLives.currentHealth1;
		actualHealth = actualHealth - playerLives.DamageHealthPlayer1();
		Assert.AreEqual (expectedHealth, actualHealth);
	}
	/// <summary>
	/// Tests the health after damage player2. I created new method in PlayerLives() to cut the health
	/// </summary>
	[Test]
	public void TestHealthAfterDamagePlayer2(){
		PlayerLives playerLives = new PlayerLives ();
		int expectedHealth = 0;
		int actualHealth = playerLives.currentHealth2;
		actualHealth = actualHealth - playerLives.DamageHealthPlayer2();
		Assert.AreEqual (expectedHealth, actualHealth);
	}

}
