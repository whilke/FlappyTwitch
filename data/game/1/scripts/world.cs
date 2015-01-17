function World::init()
{
	%world = new ScriptObject()
	{
		class = World;
	};
	
	return %world;
}

function World::setup(%this)
{
	%ground = new Scroller()
	{
		Image = "game:ground";
		size = "100 10";
		BodyType = "static";
		Position = "0 -23";
		
		repeatX = 5;
		repeatY = 1;
	};
	%ground.addToScene(gameScene);
	%this.ground = %ground;
	
	
	%background = new Scroller()
	{
		Image = "game:background";
		BodyType = "static";
		Position = "0 5";
		Size = "100 46";
		SceneLayer = 31;
		repeatX = 3;
		repeatY = 1;
	};	
	%background.addToScene(gameScene);
	%this.background = %background;

}

function World::Start(%this)
{
	%this.ground.setScrollX(20.0);	
	%this.background.setScrollX(5.0);	
}

function World::Stop(%this)
{
	%this.ground.setScrollX(0);	
	%this.background.setScrollX(0);	
}