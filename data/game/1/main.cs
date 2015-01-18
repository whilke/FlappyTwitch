function game::create( %this )
{
	exec("./scripts/constants.cs");
	exec("./scripts/prefs.cs");
	exec("./scripts/canvas.cs");
	exec("./scripts/openal.cs");
	exec("./scripts/guiProfiles.cs");
	exec("./scripts/gamelogic.cs");
	
	//init the canvas
	initializeCanvas("enBask Studios");
	
	
	//set a canvas color
	Canvas.BackgroundColor = "CornflowerBlue";
	Canvas.UseBackgroundColor = true;
	
	//init audio
	initializeOpenAL();
	
	%this.createWindow();
	%scene = %this.createScene();
	%this.setSceneToWindow(%scene);

	setRandomSeed();
	
	new RenderProxy(CannotRenderProxy)
	{
		Image = "game:CannotRender";
	};
	
	game.add(CannotRenderProxy);
	
	gameWindow.addInputListener( %this );
	gameWindow.setUseObjectInputEvents(true);

	setupGame();
	
}

function game::destroy( %this )
{
}

function game::createScene( %this )
{

	%scene = new Scene(gameScene);
	
	%scene.setGravity( 0, -59.89);

	//%scene.setDebugOn( "fps" );
	//%scene.setDebugOn( "metrics" );
	//%scene.setDebugOn( "collision" );
	//%scene.setDebugOn( "wireframe");
	//%scene.setDebugOn( "oobb");
	
	return %scene;
}

function game::createWindow( %this )
{
	new SceneWindow( gameWindow )
	{
		Profile = gameWindowProfile;
	};
    
	Canvas.setContent( gameWindow );

	
	// Set camera to a canonical state.
    %allBits = "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31";
    gameWindow.stopCameraMove();
    gameWindow.dismount();
    gameWindow.setViewLimitOff();
    gameWindow.setRenderGroups( %allBits );
    gameWindow.setRenderLayers( %allBits );
    gameWindow.setObjectInputEventGroupFilter( %allBits );
    gameWindow.setObjectInputEventLayerFilter( %allBits );
    gameWindow.setLockMouse( true );
    gameWindow.setCameraPosition( 0, 0 );
    gameWindow.setCameraSize( 100, 56 );
    gameWindow.setCameraZoom( 1 );
    gameWindow.setCameraAngle( 0 );
}

function game::setSceneToWindow( %this, %scene )
{
	gameWindow.setScene( %scene );
}
