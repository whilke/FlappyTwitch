$musicAudioType = 1;
$effectsAudioType = 2;

function initializeOpenAL()
{
	shutdownOpenAL();
	
	if (!OpenALInitDriver())
	{
		echo("audio init failed");
		$Audio::initfailed = true;
	}
	else
	{
		alxListenerf(AL_GAIN_LINEAR, $pref::Audio::masterVolume);
		
		for(%c = 1; %c <= 3; %c++)
		{
			alxSetChannelVolume(%c, $pref::Audio::channelVolume[%c]);
		}		
	} 
}

function shutdownOpenAL()
{
	openALShutdownDriver();	
}