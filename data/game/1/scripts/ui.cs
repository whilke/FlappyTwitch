$Globals::UI =0;
function UI::init()
{
	%obj = new ScriptObject()
	{
		class = "UI";
	};	
	
	UI::createUpperScore(%obj);
	UI::creategameOver(%obj);
	$Globals::UI = %obj;
	
	%playBtn = new Sprite()
	{
		class = "PlayBtn";
		Image = "game:play";
		size = "10 5";
		Position ="0 -10";
		BodyType = "static";
	};
	
	%rdy = new Sprite()
	{
		Image = "game:getready";
		size = "10 5";
		Position ="0 0";
		BodyType = "static";
	};
	%rdy.addToScene(gameScene);
	
	%playBtn.setUseInputEvents(true);

	%obj.PlayBtn = %playBtn;
	%obj.Ready = %rdy;
	%playBtn.addToScene(gameScene);
	UI::hidePlayButton();
	hideReady();
}

function UI::createGameOver(%obj)
{
	%gameOver = new Sprite()
	{
		Image = "game:gameover";
		BodyType = "static";
		Position = "0 20";
		Size = "20 10";
	};
	%obj.GameOver = %gameOver;
	
	%gameOver.addToScene(gameScene);
	
	%upperScore = new Sprite()
	{
		Image = "game:score";
		Size = "7.5 3";
		Position = "-5 17.5";
		BodyType = "static";
	};	
	
	%upperScoreValue0 = new Sprite()
	{
		Image = "game:numbers";
		Size = "1.5 1.5";
		Position = "5 17";
		BodyType = "static";
	};
	%upperScoreValue1 = new Sprite()
	{
		Image = "game:numbers";
		Size = "1.5 1.5";
		Position = "6.5 17";
		BodyType = "static";
	};
	%upperScoreValue2 = new Sprite()
	{
		Image = "game:numbers";
		Size = "1.5 1.5";
		Position = "8 17";
		BodyType = "static";
	};
		
	%upperScore.addToScene(gameScene);
	%upperScoreValue0.addToScene(gameScene);
	%upperScoreValue1.addToScene(gameScene);
	%upperScoreValue2.addToScene(gameScene);
	
	%obj.EndScore = %upperScore;
	%obj.EndScoreValue0 = %upperScoreValue0;
	%obj.EndScoreValue1 = %upperScoreValue1;
	%obj.EndScoreValue2 = %upperScoreValue2;
	
	%highScore = new Sprite()
	{
		Image = "game:highscore";
		Size = "7.5 3";
		Position = "-5 14";
		BodyType = "static";
	};	
	
	%upperScoreValue0 = new Sprite()
	{
		Image = "game:numbers";
		Size = "1.5 1.5";
		Position = "5 13.5";
		BodyType = "static";
	};
	%upperScoreValue1 = new Sprite()
	{
		Image = "game:numbers";
		Size = "1.5 1.5";
		Position = "6.5 13.5";
		BodyType = "static";
	};
	%upperScoreValue2 = new Sprite()
	{
		Image = "game:numbers";
		Size = "1.5 1.5";
		Position = "8 13.5";
		BodyType = "static";
	};
	
	
	%highScore.addToScene(gameScene);
	%upperScoreValue0.addToScene(gameScene);
	%upperScoreValue1.addToScene(gameScene);
	%upperScoreValue2.addToScene(gameScene);
	
	%obj.EndHighScore = %highScore;
	%obj.EndHighScoreValue0 = %upperScoreValue0;
	%obj.EndHighScoreValue1 = %upperScoreValue1;
	%obj.EndHighScoreValue2 = %upperScoreValue2;
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
		$Globals::UI.EndScoreValue0.setImageFrame(%s);
	}
	
	if (%score >= 10)
	{
		%s = (%score % 100) / 10;
		$Globals::UI.upperScoreValue1.setImageFrame(%s);
		$Globals::UI.EndScoreValue1.setImageFrame(%s);
	}
	
	if (%score >= 0)
	{
		%s = (%score % 10);
		$Globals::UI.upperScoreValue2.setImageFrame(%s);
		$Globals::UI.EndScoreValue2.setImageFrame(%s);
	}
}

function UI::setHighScore(%score)
{
	if (%score > 999)
		%score = 999;
	
	if (%score >= 100)
	{
		%s = %score / 100;
		$Globals::UI.EndHighScoreValue0.setImageFrame(%s);
	}
	
	if (%score >= 10)
	{
		%s = (%score % 100) / 10;
		$Globals::UI.EndHighScoreValue1.setImageFrame(%s);
	}
	
	if (%score >= 0)
	{
		%s = (%score % 10);
		$Globals::UI.EndHighScoreValue2.setImageFrame(%s);
	}
}


function UI::showGameOver()
{
	$Globals::UI.GameOver.setVisible(true);
	$Globals::UI.EndScore.setVisible(true);
	$Globals::UI.EndScoreValue[0].setVisible(true);
	$Globals::UI.EndScoreValue1.setVisible(true);
	$Globals::UI.EndScoreValue2.setVisible(true);
	$Globals::UI.EndHighScoreValue0.setVisible(true);
	$Globals::UI.EndHighScoreValue1.setVisible(true);
	$Globals::UI.EndHighScoreValue2.setVisible(true);
	$Globals::UI.EndHighScore.setVisible(true);
}

function UI::hideGameOver()
{
	$Globals::UI.GameOver.setVisible(false);
	$Globals::UI.EndScore.setVisible(false);
	$Globals::UI.EndHighScore.setVisible(false);
	$Globals::UI.EndScoreValue[0].setVisible(false);
	$Globals::UI.EndScoreValue[1].setVisible(false);
	$Globals::UI.EndScoreValue[2].setVisible(false);
	$Globals::UI.EndHighScoreValue[0].setVisible(false);
	$Globals::UI.EndHighScoreValue[1].setVisible(false);
	$Globals::UI.EndHighScoreValue[2].setVisible(false);
}

function UI::showPlayButton()
{
	%obj = $Globals::UI;
		
	%obj.PlayBtn.setVisible(true);
	
}

function UI::hidePlayButton()
{
	%obj = $Globals::UI;
	%obj.PlayBtn.setVisible(false);
}

function showReady()
{
	echo("test");
	%obj = $Globals::UI;
	%obj.Ready.setVisible(true);
}

function hideReady()
{
	%obj = $Globals::UI;
	%obj.Ready.setVisible(false);
}

function PlayBtn::onTouchDown(%this, %touchID, %worldPosition)
{
	UI::hidePlayButton();
	$Globals::State = 1;
		
	schedule(16, 0, resetGame);	
	schedule(32, 0, showReady);
	
}