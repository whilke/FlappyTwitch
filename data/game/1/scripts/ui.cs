$Globals::UI =0;
function UI::init()
{
	%obj = new ScriptObject()
	{
		class = "UI";
	};	
	$Globals::UI = %obj;
	
	UI::createUpperScore();
	UI::creategameOver();
}

function UI::createGameOver(%obj)
{
	%gameOver = new Sprite()
	{
		Image = "game:gameover";
		BodyType = "static";
		Position = "0 0";
		Size = "10 10";
	}
	%gameOver.addToScene(%gameOver);
	%obj.GameOver = %gameOver;
}

function UI::createUpperScore(%obj)
{
	%upperScore = new Sprite()
	{
		Image = "game:score";
		Size = "7.5 3";
		Position = "44 25";
		BodyType = "static";
	};	
	%upperScore.addToScene(gameScene);

	%upperScoreValue0 = new Sprite()
	{
		Image = "game:numbers";
		Size = "1.5 1.5";
		Position = "46 24.8";
		BodyType = "static";
	};
	%upperScoreValue1 = new Sprite()
	{
		Image = "game:numbers";
		Size = "1.5 1.5";
		Position = "47.5 24.8";
		BodyType = "static";
	};
	%upperScoreValue2 = new Sprite()
	{
		Image = "game:numbers";
		Size = "1.5 1.5";
		Position = "49 24.8";
		BodyType = "static";
	};
	
	%upperScoreValue0.addToScene(gameScene);
	%upperScoreValue1.addToScene(gameScene);
	%upperScoreValue2.addToScene(gameScene);
	
	%obj.UpperScore = %upperScore;
	%obj.upperScoreValue0 = %upperScoreValue0;
	%obj.upperScoreValue1 = %upperScoreValue1;
	%obj.upperScoreValue2 = %upperScoreValue2;
		
}

function UI::setScore(%score)
{
	if (%score > 999)
		%score = 999;
	
	if (%score >= 100)
	{
		%s = %score / 100;
		$Globals::UI.upperScoreValue0.setImageFrame(%s);
	}
	
	if (%score >= 10)
	{
		%s = (%score % 100) / 10;
		$Globals::UI.upperScoreValue1.setImageFrame(%s);
	}
	
	if (%score >= 0)
	{
		%s = (%score % 10);
		$Globals::UI.upperScoreValue2.setImageFrame(%s);
	}
}


function UI::showGameOver()
{
	
}
