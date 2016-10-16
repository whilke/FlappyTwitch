exec("./player.cs");
exec("./world.cs");
exec("./ui.cs");

function setupGame()
{
	$Globals::currentScore = 0;
	$Globals::highScore = 0;

	resetGame();
	UI::showPlayButton();

}

function endGame()
{
	stopGame();
	$Globals::State = 3;
	UI::setHighScore($Globals::highScore);	
	UI::showGameOver();	
	UI::showPlayButton();
}

function resetGame()
{
	gameScene.clear();
	$Globals::Player = Player::init();
	$Globals::World = World::init();
	UI::init();
	UI::hideGameOver();

	$Globals::World.setup();
	$Globals::currentScore= 0;
}

function startGame()
{
	hideReady();
	$Globals::Player.Start();
	$Globals::World.Start();
	UI::Start();
}

function stopGame()
{
	$Globals::Player.Stop();
	$Globals::World.Stop();
	UI::Stop();
}

function increaseScore()
{
	$Globals::currentScore++;
	if ($Globals::highScore < $Globals::currentScore)
	{
		$Globals::highScore = $Globals::currentScore;
	}
	UI::setScore($Globals::currentScore);
	
}

function gameWindow::onTouchDown(%this, %touchID, %worldPos, %mouseClick)
{
	if ($Globals::State == 1)
	{
		//move-player state
		$Globals::State = 2;
		startGame();
	}	
	
	if ($Globals::State == 2)
	{
		//play game state
		$Globals::Player.Flap();	
		return;
	}
	
	if ($Globals::State == 3)
	{
		//game over state
		$Globals::State = 0;
	}
}

function gameWindow::OnTouchUp(%this, %touchID, %worldPos, %mouseClicks)
{
}




