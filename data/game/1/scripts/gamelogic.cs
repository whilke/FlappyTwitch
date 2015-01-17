exec("./player.cs");
exec("./world.cs");

function setupGame()
{
	$Globals::currentScore = 0;
	$Globals::highScore= 0;
	
	resetGame();
}

function endGame()
{
	stopGame();
	$Globals::State = 3;
}

function resetGame()
{
	gameScene.clear();
	$Globals::Player = Player::init();
	$Globals::World = World::init();

	$Globals::World.setup();
	$Globals::currentScore= 0;
}

function startGame()
{
	$Globals::Player.Start();
	$Globals::World.Start();
}

function stopGame()
{
	$Globals::Player.Stop();
	$Globals::World.Stop();
}

function increaseScore()
{
	$Globals::currentScore++;
	if ($Globals::highScore < $Globals::currentScore)
	{
		$Globals::highScore = $Globals::currentScore;
	}
	
	echo("currentScore:" SPC $Globals::currentScore);
}

function gameWindow::onTouchDown(%this, %touchID, %worldPos, %mouseClick)
{
	if ($Globals::State == 0)
	{
		//start-game state
		$Globals::State = 1;
		resetGame();
		return;
	}
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

	if ($Globals::State == 2)
	{
		$Globals::Player.setLinearVelocity(0, -5);
	}
}




