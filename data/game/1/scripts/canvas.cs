$canvasCreated = false;

function initializeCanvas( %windowName )
{
	if ($canvasCreated)
	{
		error("canvas already created");
		return;
	}
	
	videoSetGammaCorrection($pref::OpenGL::gammaCorrection);
	
	if (!createCanvas(%windowName))
	{
		error("canvas create failed!");
		quit();
	}
	
	if ($pref::Video::windowedRes !$= "")
		%res = $pref::Video::windowedRes;
	else
		%res = $pref::Video::defaultResolution;
		
	setScreenMode(%res._0, %res._1, %res._2, $pref::Video::fullScreen);
	
	$canvasCreated = true;
}

function resetCanvas()
{
	if (isObject(Canvas))
	{
		Canvas.repaint();
	}
}

