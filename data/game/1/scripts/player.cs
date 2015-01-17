function Player::init()
{
	%player = new Sprite()
	{
		class = "Player";
		Animation = "game:PlayerAnim";
		size = "10 5";		
		GravityScale = 0;
	};
	
	%fixture = %player.createCircleCollisionShape(2, 0, -0.5);
	%player.setCollisionShapeDensity(%fixture, 40);
	%player.setCollisionShapeFriction(%fixture, 100);
		
	%player.addToScene( gameScene );
	
	return %player;
}

function Player::Start(%this)
{
	%this.setGravityScale(1);
	%this.setPosition(-30, 0);
}

function Player::Stop(%this)
{
	%this.setGravityScale(0);
}

function Player::Flap(%this)
{
	%this.setLinearVelocity(0, 40);
}