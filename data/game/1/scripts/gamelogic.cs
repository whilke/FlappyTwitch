exec("./player.cs");
exec("./world.cs");

function setupGame()
{
	$Globals::Player = Player::init();
	$Globals::World = World::init();
	
	resetGame();
}

function resetGame()
{
	$Globals::World.setup();
	$Globals::State = 0;
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

function gameWindow::onTouchDown(%this, %touchID, %worldPos, %mouseClick)
{
	if ($Globals::State == 0)
	{
		//start-game state
		$Globals::State = 1;
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
}

function gameWindow::OnTouchUp(%this, %touchID, %worldPos, %mouseClicks)
{

	if ($Globals::State == 2)
	{
		$Globals::Player.setLinearVelocity(0, -5);
	}
}




