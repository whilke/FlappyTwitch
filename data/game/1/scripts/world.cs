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
	
	%ground.createEdgeCollisionShape(-100, 5, 100, 5);
	%ground.createEdgeCollisionShape(-100, 51, 100, 51);
	
	
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
	
	%this.Tick();
}

function World::Stop(%this)
{
	%this.ground.setScrollX(0);	
	%this.background.setScrollX(0);	
}

function World::Tick(%this)
{
	%this.createPipe(60);	
	%this.tickId = %this.schedule(1000, Tick);
}


function World::createPipe(%this, %x)
{
	%fullWindowSize = 56;
	%groundSize= 10;
	
	%windowSize = %fullWindowSize - %groundSize;
	
	%halfFullWindowSize = %fullWindowSize * 0.5;
	%halfWindowSize = %windowSize * 0.5;
	%space = 10;
		
	
	%totalPipeSize =  ( %windowSize - %space);
	
	%upperPipeSize = %totalPipeSize * 0.5;
	%lowerPipeSize = %totalPipeSize * 0.5;
	
	
	%upperPipe = new Sprite()
	{
		Image = "game:Pipe";
		Frame = 0;
		GravityScale = 0;		
		Size = 8 SPC  %upperPipeSize;
		Position = %x SPC  %halfFullWindowSize - (%upperPipeSize * 0.5);
	};
	%upperPipe.setFlipY(true);
	
	%lowerPipe = new Sprite()
	{
		Image = "game:Pipe";
		Frame = 0;
		GravityScale = 0;		
		Size = 8 SPC %lowerPipeSize;
		Position = %x SPC -%halfFullWindowSize + (%lowerPipeSize * 0.5) + %groundSize;
	};
	
	%fixture = %upperPipe.createPolygonBoxCollisionShape( %upperPipe.getSize() );
	%upperPipe.setCollisionShapeDensity(%fixture, 800);
	%fixture = %lowerPipe.createPolygonBoxCollisionShape( %lowerPipe.getSize() );
	%lowerPipe.setCollisionShapeDensity(%fixture, 800);
	
	%upperPipe.setLinearVelocity(-20, 0);
	%lowerPipe.setLinearVelocity(-20, 0);
	
	
	%upperPipe.addToScene(gameScene);
	%lowerPipe.addToScene(gameScene);
	
}