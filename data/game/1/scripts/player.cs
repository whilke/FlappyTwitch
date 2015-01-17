function Player::init()
{
	%player = new Sprite()
	{
		class = "Player";
		Animation = "game:PlayerAnim";
		size = "10 5";		
		GravityScale = 0;
	};
		
	%player.addToScene( gameScene );
	
	return %player;
}

function Player::Start(%this)
{
	%this.setPosition(-30, 0);
}

function Player::Stop(%this)
{
}