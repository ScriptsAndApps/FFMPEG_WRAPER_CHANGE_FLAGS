# FFMPEG_WRAPER_CHANGE_FLAGS
some programs use ffmpeg, you can now put this wrapper around it and edit arguments / flags to your likings without altering the program



1. Rename the original ffmpeg.exe in the program folder to ffmpeg_original.exe

2. Then place this file also called FFMPEG.EXE in the program folder

3. Run the new FFMPEG.EXE once and change the ffmpeg_arguments_hack.ini to your preferences

Now your program will use the altered arguments if done corretly

I use it for programs that do not allow you to convert full audio/video length, so it will ignore the -t limit 
you can use any argument you want to alter (use ADD_ARGUMENTS_HERE to add additional arguments)
