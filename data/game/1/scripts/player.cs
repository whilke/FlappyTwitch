function Player::init()
{
	%player = new Sprite()
	{
		class = "Player";
		Animation = "game:PlayerAnim";
		size = "50 24";		
		GravityScale = 0;
	};
	
	%player.addToScene( gameScene );
	
}