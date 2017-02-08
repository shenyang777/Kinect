using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kinect.Tools;

namespace Microsoft.Samples.Kinect.DepthAndColor
{
    class PlaybackHelper
    {
        //static int num=0;
        public static void PlaybackClip(string filePath, uint loopCount,ref int num)
        {
            using (KStudioClient client = KStudio.CreateClient())
            {
                client.ConnectToService();

                using (KStudioPlayback playback = client.CreatePlayback(filePath))
                {
                    playback.LoopCount = loopCount;
                    
                    playback.Start();

                    while ((playback.State == KStudioPlaybackState.Playing) || (playback.State == KStudioPlaybackState.Paused))
                    {

                        
                        {
                            if ((playback.State == KStudioPlaybackState.Playing))
                            {
                                ///////////////////////////////////////////////////////playback.Pause();
                            }
                            if (playback.State == KStudioPlaybackState.Paused)
                            {
                                playback.StepOnce();
                                Thread.Sleep(100);
                                num = num + 1;
                            }
                            
                        }
                        
                        Thread.Sleep(100);
                    }
                    playback.Stop();            


                    if (playback.State == KStudioPlaybackState.Error)
                    {
                        throw new InvalidOperationException("Error: Playback failed!");
                    }
                }

                client.DisconnectFromService();
            }
        }
    }
}
